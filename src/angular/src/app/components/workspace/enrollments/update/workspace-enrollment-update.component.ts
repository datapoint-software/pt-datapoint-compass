import { Component, inject, OnDestroy, OnInit, ViewChild, viewChild } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helper";
import { badRequestOrConflict, conflict } from "@app/helpers/service.helper";
import { DistrictModel } from "@app/services/districts/district.abstractions";
import { DistrictService } from "@app/services/districts/district.service";
import { NationalityModel } from "@app/services/nationalities/nationality.service.abstractions";
import { WorkspaceEnrollmentService } from "@app/services/workspace/enrollments/workspace-enrollment.service";
import { WorkspaceEnrollmentFacilityModel, WorkspaceEnrollmentServiceModel } from "@app/services/workspace/enrollments/workspace-enrollment.service.abstractions";
import { startWith, Subject, takeUntil } from "rxjs";

@Component({
  imports: [ ReactiveFormsModule, RouterLink, SuiFormGroupComponent, SuiModalComponent ],
  selector: "app-workspace-enrollment-update",
  standalone: true,
  templateUrl: "workspace-enrollment-update.component.html"
})
export class WorkspaceEnrollmentUpdateComponent implements OnDestroy, OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _districts = inject(DistrictService);
  private readonly _enrollments = inject(WorkspaceEnrollmentService);
  private readonly _fb = inject(FormBuilder);
  private readonly _loadingOverlay = inject(LoadingOverlay);
  private readonly _router = inject(Router);

  @ViewChild("success") success!: SuiModalComponent;

  readonly districts = new Map<string, DistrictModel[]>();

  readonly form: FormGroup<{
    serviceId: FormControl<string | null>;
    facilityId: FormControl<string | null>;
    start: FormControl<string | null>;
    student?: FormGroup<{
      name: FormControl<string | null>;
      birth: FormControl<string | null>;
      nationality: FormControl<string | null>;
      birthplace: FormControl<string | null>;
    }>;
  }> = this._fb.group({
    serviceId: this._fb.control("", [ Validators.required ]),
    facilityId: this._fb.control("", [ Validators.required ]),
    start: this._fb.control("", [ ])
  });

  readonly successActions: SuiModalComponentAction[] = [{
    fn: () => this._router.navigate([ "/workspace/enrollments" ]),
    label: $localize `:@@workspace-enrollment-update-success-modal-primary:Go back to search`,
    type: "primary"
  }];

  country!: string;
  district?: string;
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  facilities!: WorkspaceEnrollmentFacilityModel[];
  nationalities!: NationalityModel[];
  number?: string;
  services!: WorkspaceEnrollmentServiceModel[];

  addStudentControls(): void {

    const student = this.form.controls.student = this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control(this.country, [ Validators.required ]),
      birthplace: this._fb.control(this.district, [ Validators.required ])
    }) as FormGroup<{
      name: FormControl<string | null>;
      birth: FormControl<string | null>;
      nationality: FormControl<string | null>;
      birthplace: FormControl<string | null>;
    }>;

    student.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .pipe(startWith(this.country))
      .subscribe((nationality) => this._nationalityChanges(student, nationality))
  }

  navigate(commands: any[]): Promise<boolean> {
    return this._router.navigate(commands);
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model, nationalities }) => {

        this.country = model.country;
        this.district = model.district;
        this.enrollmentId = model.enrollmentId;
        this.enrollmentRowVersionId = model.enrollmentRowVersionId;
        this.facilities = model.facilities;
        this.nationalities = nationalities;
        this.number = model.number;
        this.services = model.services;

        if (model.form)
          this.form.reset(model.form);
      });
  }

  async submit(): Promise<void> {

    if (this.form.invalid)
      return;

    const success = await this._loadingOverlay.merge(async () => {

      const response = await this._enrollments.submitUpdate({
        enrollmentId: this.enrollmentId,
        enrollmentRowVersionId: this.enrollmentRowVersionId,
        form: fromValueOf(this.form)
      })

        .catch(badRequestOrConflict((response) => {
          applyErrorResponse(this.form, response);
          return null;
        }));

      if (!response)
        return false;

      this.enrollmentId = response.enrollmentId;
      this.enrollmentRowVersionId = response.enrollmentRowVersionId;
      this.number = response.number;

      history.replaceState(
        history.state, "",
        document.location.pathname.replace("/_", `/${this.enrollmentId}`));

      return true;
    });

    if (success)
      this.success.open();
  }

  private _nationalityChanges(fg: FormGroup, nationality: string | null) {

    if (!nationality) {
      fg.removeControl("birthplace");
      return;
    }

    this._loadingOverlay.merge(async () => {

      let districts = this.districts.get(nationality);

      if (!districts) {

          districts = await this._districts.getAll({
            countryCode: nationality
          });

          this.districts.set(nationality, districts);
      }

      if (districts.length > 0)
        fg.addControl("birthplace", [ Validators.required ]);
      else
        fg.removeControl("birthplace");
    });
  }
}
