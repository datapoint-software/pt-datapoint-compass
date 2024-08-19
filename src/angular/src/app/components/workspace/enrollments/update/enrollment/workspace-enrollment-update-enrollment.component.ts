import { Component, inject, OnInit } from "@angular/core";
import { FormArray, FormControl, ReactiveFormsModule } from "@angular/forms";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { WorkspaceEnrollmentUpdateComponent } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component";
import { DateInputDirective } from "@app/directives/date-input/date-input.directive";

@Component({
  imports: [ DateInputDirective, ReactiveFormsModule, SuiFormGroupComponent ],
  selector: "app-workspace-enrollment-update-enrollment",
  standalone: true,
  templateUrl: "workspace-enrollment-update-enrollment.component.html"
})
export class WorkspaceEnrollmentUpdateEnrollmentComponent implements OnInit {


  private readonly _update: WorkspaceEnrollmentUpdateComponent = inject(WorkspaceEnrollmentUpdateComponent);

  facilities = this._update.facilities;
  form = this._update.form;
  services = this._update.services;

  formControlFacilityEnabled(formControls: FormArray<FormControl<string | null>>, formControl: FormControl<unknown>, facilityId: string): boolean {
    return formControls.controls
      .filter(fc => fc !== formControl)
      .filter(fc => fc.value === facilityId)
      .length < 1;
  }

  ngOnInit(): void {
  }
}
