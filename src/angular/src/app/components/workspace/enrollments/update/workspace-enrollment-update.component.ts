import { Component, ContentChild, inject, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, ActivatedRouteSnapshot, ResolveData, Router, RouterLink, RouterOutlet } from "@angular/router";
import { WorkspaceEnrollmentUpdateComponentClient } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client";
import { WorkspaceEnrollmentUpdateComponentFacilityModel, WorkspaceEnrollmentUpdateComponentServiceModel } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client.abstractions";
import { WorkspaceEnrollmentUpdateComponentForm } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component.abstractions";
import { DataBsToggleDropdownDirective } from "@app/directives/data-bs-toggle-dropdown/data-bs-toggle-dropdown.directive";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";
import { badRequestOrConflict } from "@app/helpers/api.helpers";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helpers";
import { Subject, takeUntil } from "rxjs";
import { SuiModalComponent } from "../../../sui/modal/sui-modal.component";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";
import { APP_LOCALE } from "@app/app.constants";
import { CountryModel } from "@app/api/countries/country.client.abstractions";
import { CountryClient } from "@app/api/countries/country.client";
import { WorkspaceEnrollmentUpdateStudentComponent } from "@app/components/workspace/enrollments/update/student/workspace-enrollment-update-student.component";
import { WorkspaceEnrollmentUpdateEnrollmentComponent } from "@app/components/workspace/enrollments/update/enrollment/workspace-enrollment-update-enrollment.component";

@Component({
  imports: [
    DataBsToggleDropdownDirective,
    ReactiveFormsModule,
    RouterLink,
    RouterOutlet,
    SuiModalComponent,
    WorkspaceEnrollmentUpdateEnrollmentComponent,
    WorkspaceEnrollmentUpdateStudentComponent
  ],
  selector: "app-workspace-enrollment-update",
  standalone: true,
  templateUrl: "workspace-enrollment-update.component.html"
})
export class WorkspaceEnrollmentUpdateComponent implements OnDestroy, OnInit {

  static readonly resolve: ResolveData = ({

    countries: () => inject(CountryClient).search(),

    model: async (route: ActivatedRouteSnapshot) => {

      let enrollmentId = route.paramMap.get("enrollmentId");

      return inject(WorkspaceEnrollmentUpdateComponentClient).get({
        ...((enrollmentId && enrollmentId.length > 1) ? ({ enrollmentId }) : ({})),
        languageCode: APP_LOCALE
      });
    }
  });

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _loadingOverlayFeature: LoadingOverlayFeature = inject(LoadingOverlayFeature);
  private readonly _router: Router = inject(Router);
  private readonly _workspaceEnrollmentUpdateComponentClient: WorkspaceEnrollmentUpdateComponentClient = inject(WorkspaceEnrollmentUpdateComponentClient);

   @ViewChild("success") success!: SuiModalComponent;
  successActions: SuiModalComponentAction[] = [
    {
      label: $localize `:@@workspace-enrollment-update-success-modal-go-to-search:Go to search`,
      type: "primary",
      fn: () => {
        this.success.close();
        this._router.navigate([ "/workspace/enrollments" ]);
      }
    }
  ];

  form: WorkspaceEnrollmentUpdateComponentForm = this._fb.group({
    serviceId: this._fb.control("", [ Validators.required ]),
    facilityId: this._fb.control("", [ ]),
    start: this._fb.control("", [ ]),
    comments: this._fb.control("", [ Validators.maxLength(4096) ])
  });

  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  number?: string;
  countryCode!: string;
  countries!: CountryModel[];
  facilities!: WorkspaceEnrollmentUpdateComponentFacilityModel[];
  section!: string;
  services!: WorkspaceEnrollmentUpdateComponentServiceModel[];

  @ContentChild(WorkspaceEnrollmentUpdateStudentComponent)
  student?: WorkspaceEnrollmentUpdateStudentComponent;

  addStudent(): void {
    this.form.addControl("student", this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", []),
      nationality: this._fb.control(this.countryCode, [ Validators.required ])
    }));
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ countries, model }) => {
        this.enrollmentId = model.enrollmentId;
        this.enrollmentRowVersionId = model.enrollmentRowVersionId;
        this.number = model.number;
        this.countryCode = model.countryCode;
        this.countries = countries;
        this.facilities = model.facilities;
        this.services = model.services;

        if (model.form)
          this.form.reset(model.form);

        if (this.enrollmentId)
          this.form.controls.serviceId.disable();
      });

    this._activatedRoute.paramMap
      .pipe(takeUntil(this._destroy$))
      .subscribe((params) => {
        this._sectionChanges(params.get("section")!)
      });
  }

  async submit(): Promise<void> {

    if (this.form.invalid)
      return;

    await this._loadingOverlayFeature.enqueueWhile(async () => {

      const response = await this._workspaceEnrollmentUpdateComponentClient.submit({
        enrollmentId: this.enrollmentId,
        enrollmentRowVersionId: this.enrollmentRowVersionId,
        form: fromValueOf(this.form)
      })

        .catch(badRequestOrConflict((response) => {
          applyErrorResponse(this.form, response);
          console.log(this.form.errors);
        }));

      if (!response)
        return;

      if (response.enrollmentId && !this.enrollmentId)
        window.history.replaceState(window.history.state, "", `/workspace/enrollments/${response.enrollmentId}`);

      this.enrollmentId = response.enrollmentId;
      this.enrollmentRowVersionId = response.enrollmentRowVersionId;
      this.number = response.number;

      this.form.controls.serviceId.disable();

      this.success.open();
    });
  }

  private _sectionChanges(section: string) {

    this.section = section;

    if (section === "student" && !this.form.controls.student)
      this.addStudent();
  }
}
