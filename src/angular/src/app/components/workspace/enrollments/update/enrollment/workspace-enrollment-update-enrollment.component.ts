import { Component, inject, Input, OnChanges, OnDestroy, OnInit, SimpleChanges } from "@angular/core";
import { FormArray, FormBuilder, FormControl, ReactiveFormsModule, Validators } from "@angular/forms";
import { WorkspaceEnrollmentSearchComponentServiceModel } from "@app/api/components/workspace/enrollments/search/workspace-enrollment-search-component.client.abstractions";
import { WorkspaceEnrollmentUpdateComponentFacilityModel } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client.abstractions";
import { EnrollmentStatus } from "@app/app.enums";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { WorkspaceEnrollmentUpdateComponentForm } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component.abstractions";
import { DateInputDirective } from "@app/directives/date-input/date-input.directive";
import { filter, startWith, Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DateInputDirective, ReactiveFormsModule, SuiFormGroupComponent ],
  selector: "app-workspace-enrollment-update-enrollment",
  standalone: true,
  templateUrl: "workspace-enrollment-update-enrollment.component.html"
})
export class WorkspaceEnrollmentUpdateEnrollmentComponent implements OnChanges, OnDestroy, OnInit {

  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);

  @Input({ required: true }) facilities!: WorkspaceEnrollmentUpdateComponentFacilityModel[];
  @Input({ required: true }) form!: WorkspaceEnrollmentUpdateComponentForm;
  @Input({ required: true }) services!: WorkspaceEnrollmentSearchComponentServiceModel[];
  @Input({ required: true }) status!: EnrollmentStatus;

  addFacilityEnabled!: boolean;
  maximumFacilityCount: number = 2; // TODO <joao.pl.lopes> get this from component model

  addFacility(): void {

    if (!this.addFacilityEnabled)
      return;

    const formControl = this._fb.control("", [ Validators.required ]);
    this._facilityControlSubscriptions(formControl);

    this.form.controls.facilityIds!.push(formControl);
  }

  formControlFacilityEnabled(formControls: FormArray<FormControl<string | null>>, formControl: FormControl<unknown>, facilityId: string): boolean {
    return formControls.controls
      .filter(fc => fc !== formControl)
      .filter(fc => fc.value === facilityId)
      .length < 1;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.addFacilityEnabled = this.status === EnrollmentStatus.Draft && this.addFacilityEnabled;
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    this.form.controls.facilityIds?.valueChanges
      .pipe(takeUntil(this._destroy$))
      .pipe(startWith(this.form.controls.facilityIds.value))
      .subscribe((facilityIds) => this._facilitiesChanged(facilityIds));

    this.form.controls.facilityIds?.controls.slice(1)
      .forEach((formControl) => this._facilityControlSubscriptions(formControl));
  }

  private _facilitiesChanged(facilityIds: (string | null)[]): void {
    this.addFacilityEnabled = (
      facilityIds.length < this.maximumFacilityCount &&
      facilityIds.length < this.facilities.length
    );
  }

  private _facilityControlSubscriptions(formControl: FormControl<string | null>): void {
    formControl.valueChanges
      .pipe(takeUntil(this._destroy$))
      .pipe(filter((value) => !value))
      .subscribe(() => this.form.controls.facilityIds!.removeAt(
        this.form.controls.facilityIds!.controls.indexOf(formControl)
      ));
  }
}
