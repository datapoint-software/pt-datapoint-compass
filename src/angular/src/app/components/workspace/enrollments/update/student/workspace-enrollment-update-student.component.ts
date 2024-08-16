import { AfterViewChecked, Component, inject, NgZone, OnInit } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { WorkspaceEnrollmentUpdateComponent } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component";
import { DateInputDirective } from "@app/directives/date-input/date-input.directive";

@Component({
  imports: [ DateInputDirective, ReactiveFormsModule, SuiFormGroupComponent ],
  selector: "app-workspace-enrollment-update-student",
  standalone: true,
  templateUrl: "workspace-enrollment-update-student.component.html"
})
export class WorkspaceEnrollmentUpdateStudentComponent implements OnInit, AfterViewChecked {

  private readonly _ngZone: NgZone = inject(NgZone);
  private readonly _router: Router = inject(Router);
  private readonly _update: WorkspaceEnrollmentUpdateComponent = inject(WorkspaceEnrollmentUpdateComponent);

  form = this._update.form;
  nationalities = this._update.countries;

  ngAfterViewChecked(): void {
    if (!this.form.controls.student)
      setTimeout(() => this._ngZone.run(() => this._update.addStudent()), 0);
  }

  ngOnInit(): void {
  }

}
