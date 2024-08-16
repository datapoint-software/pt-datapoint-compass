import { Component, inject, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, NavigationEnd, ResolveFn, Router, RouterLink, RouterOutlet } from "@angular/router";
import { WorkspaceEnrollmentUpdateComponentClient } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client";
import { WorkspaceEnrollmentUpdateComponentFacilityModel, WorkspaceEnrollmentUpdateComponentModel, WorkspaceEnrollmentUpdateComponentServiceModel } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client.abstractions";
import { WorkspaceEnrollmentUpdateEnrollmentComponent } from "@app/components/workspace/enrollments/update/enrollment/workspace-enrollment-update-enrollment.component";
import { WorkspaceEnrollmentUpdateComponentForm } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component.abstractions";
import { DataBsToggleDropdownDirective } from "@app/directives/data-bs-toggle-dropdown/data-bs-toggle-dropdown.directive";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";
import { badRequestOrConflict } from "@app/helpers/api.helpers";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helpers";
import { filter, Subject, takeUntil } from "rxjs";
import { SuiModalComponent } from "../../../sui/modal/sui-modal.component";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";

@Component({
  imports: [DataBsToggleDropdownDirective, ReactiveFormsModule, RouterLink, RouterOutlet, WorkspaceEnrollmentUpdateEnrollmentComponent, SuiModalComponent],
  selector: "app-workspace-enrollment-update",
  standalone: true,
  templateUrl: "workspace-enrollment-update.component.html"
})
export class WorkspaceEnrollmentUpdateComponent implements OnDestroy, OnInit {

  static readonly model: ResolveFn<WorkspaceEnrollmentUpdateComponentModel> = async (route) => {

    let enrollmentId = route.paramMap.get("enrollmentId");

    return inject(WorkspaceEnrollmentUpdateComponentClient).get({
      ...((enrollmentId && enrollmentId.length > 1) ? ({ enrollmentId }) : ({}))
    });
  }

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _loadingOverlayFeature: LoadingOverlayFeature = inject(LoadingOverlayFeature);
  private readonly _router: Router = inject(Router);
  private readonly _workspaceEnrollmentUpdateComponentClient: WorkspaceEnrollmentUpdateComponentClient = inject(WorkspaceEnrollmentUpdateComponentClient);

  section!: string;

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
  facilities!: WorkspaceEnrollmentUpdateComponentFacilityModel[];
  services!: WorkspaceEnrollmentUpdateComponentServiceModel[];

  addStudent(): void {
    this.form.addControl("student", this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [])
    }));
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this.enrollmentId = model.enrollmentId;
        this.enrollmentRowVersionId = model.enrollmentRowVersionId;
        this.number = model.number;
        this.facilities = model.facilities;
        this.services = model.services;

        if (model.form)
          this.form.reset(model.form);

        if (this.enrollmentId)
          this.form.controls.serviceId.disable();
      });

    this._router.events
      .pipe(takeUntil(this._destroy$))
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe((e) => this._updateSectionFromUrl(e.url));

    this._updateSectionFromUrl(this._router.url);
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

  private _updateSectionFromUrl(url: string) {
    this.section =
      url.endsWith("student") ? "student" :
        "enrollment";
  }
}
