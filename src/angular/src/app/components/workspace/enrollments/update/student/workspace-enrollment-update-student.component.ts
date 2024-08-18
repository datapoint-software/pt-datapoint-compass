import { AfterViewChecked, Component, inject, NgZone, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { CanActivateFn, Router } from "@angular/router";
import { DistrictClient } from "@app/api/districts/district.client";
import { DistrictModel } from "@app/api/districts/district.client.abstractions";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { WorkspaceEnrollmentUpdateComponent } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component";
import { DateInputDirective } from "@app/directives/date-input/date-input.directive";
import { startWith, Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DateInputDirective, ReactiveFormsModule, SuiFormGroupComponent ],
  selector: "app-workspace-enrollment-update-student",
  standalone: true,
  templateUrl: "workspace-enrollment-update-student.component.html"
})
export class WorkspaceEnrollmentUpdateStudentComponent implements OnDestroy, OnInit {

  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _districtClient: DistrictClient = inject(DistrictClient);
  private readonly _update: WorkspaceEnrollmentUpdateComponent = inject(WorkspaceEnrollmentUpdateComponent);

  birthplaces?: DistrictModel[];
  nationalities = this._update.countries;
  student = this._update.form.controls.student!;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this.student.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .pipe(startWith(this.student.controls.nationality.value))
      .subscribe((nationality) => this._nationalityChanges(nationality));
  }

  private async _nationalityChanges(nationality: string | null): Promise<void> {

    this.student.removeControl("birthplace");

    if (!nationality)
      return;

    this.birthplaces = await this._districtClient.search({
      countryCode: nationality
    });

    if (this.birthplaces.length > 0) {
      this.student.addControl(
        "birthplace",
        this._fb.control("", [ Validators.required ])
      );
    }
  }
}
