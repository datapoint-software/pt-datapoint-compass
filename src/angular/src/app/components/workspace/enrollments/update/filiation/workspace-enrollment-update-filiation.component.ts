import { Component, inject } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { DistrictClient } from "@app/api/districts/district.client";
import { DistrictModel } from "@app/api/districts/district.client.abstractions";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiPostalAddressFormComponent } from "@app/components/sui/postal-address-form/sui-postal-address-form.component";
import { WorkspaceEnrollmentUpdateComponent } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component";
import { DateInputDirective } from "@app/directives/date-input/date-input.directive";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DateInputDirective, ReactiveFormsModule, SuiFormGroupComponent, SuiPostalAddressFormComponent ],
  selector: "app-workspace-enrollment-update-filiation",
  standalone: true,
  templateUrl: "workspace-enrollment-update-filiation.component.html"
})
export class WorkspaceEnrollmentUpdateFiliationComponent {

  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _districtClient: DistrictClient = inject(DistrictClient);
  private readonly _update: WorkspaceEnrollmentUpdateComponent = inject(WorkspaceEnrollmentUpdateComponent);

  birthplaces?: DistrictModel[];
  countryCode = this._update.countryCode;
  nationalities = this._update.countries;
  filiations = this._update.form.controls.filiation!;

  addResidence(index: number): void {

    const residence = this._fb.group({
      countryCode: this._fb.control(this.countryCode, [])
    });

    const filiation = this.filiations.at(index);

    filiation!.addControl("residence", residence);
  }

  lookupResidenceByAreaCode(areaCode: string): void {
    alert(areaCode);
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    this.filiations.controls.forEach((filiation, index) => {

      filiation.controls.nationality.valueChanges
        .pipe(takeUntil(this._destroy$))
        .subscribe((nationality) => this._nationalityChanges(nationality, index));

      this._birthplaceOptions(index);
    });


  }

  pushFiliation(): void {
    this._update.pushFiliation();
  }

  private async _birthplaceOptions(index: number): Promise<void> {

    const filiation = this.filiations.at(index);

    const countryCode = filiation.controls.nationality.value;

    if (countryCode)
      this.birthplaces = await this._districtClient.search({ countryCode });
    else
      delete this.birthplaces;
  }

  private async _nationalityChanges(nationality: string | null, index: number): Promise<void> {

    const filiation = this.filiations.at(index);

    filiation.removeControl("birthplace");

    if (!nationality)
      return;

    await this._birthplaceOptions(index);

    if (this.birthplaces?.length) {
      filiation.addControl(
        "birthplace",
        this._fb.control("", [ Validators.required ])
      );
    }
  }
}
