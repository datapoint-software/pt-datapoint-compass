import { Component, inject, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule, ValidatorFn, Validators } from "@angular/forms";
import { SuiPostalAddressFormPortugalComponentClient } from "@app/api/components/sui/postal-address-form/portugal/postal-address-form-portugal-component.client";
import { PostalAddressFormPortugalComponentCountyModel, PostalAddressFormPortugalComponentDistrictModel, PostalAddressFormPortugalComponentLocalityModel, PostalAddressFormPortugalComponentSearchResultModel, PostalAddressFormPortugalComponentStreetModel } from "@app/api/components/sui/postal-address-form/portugal/postal-address-form-portugal-component.client.abstractions";
import { APP_INPUT_DEBOUNCE_TIME } from "@app/app.constants";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { SuiPostalAddressFormComponent } from "@app/components/sui/postal-address-form/sui-postal-address-form.component";
import { PostalAddressFormGroup } from "@app/components/sui/postal-address-form/sui-postal-address-form.component.abstractions";
import { debounceTime, filter, map, Subject, takeUntil, tap } from "rxjs";

const POSTAL_CODE = /^\d{4}\-\d{3}$/;

const POSTAL_CODE_VALIDATORFN: ValidatorFn = (formControl) => {

  const value = formControl.value;

  if (!value || ("string" === typeof value && POSTAL_CODE.test(value)))
    return null;

  return ({ postalcode: true })
};

@Component({
  imports: [ ReactiveFormsModule, SuiFormGroupComponent, SuiModalComponent ],
  selector: "app-sui-postal-address-form-portugal",
  standalone: true,
  templateUrl: "sui-postal-address-form-portugal.component.html"
})
export class SuiPostalAddressFormPortugalComponent implements OnDestroy, OnInit {

  private readonly _base: SuiPostalAddressFormComponent = inject(SuiPostalAddressFormComponent);
  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _client: SuiPostalAddressFormPortugalComponentClient = inject(SuiPostalAddressFormPortugalComponentClient);

  @ViewChild("areaCodeUnknown") private _areaCodeUnknown!: SuiModalComponent;
  private _searchResult?: PostalAddressFormPortugalComponentSearchResultModel;

  get formGroupContext(): PostalAddressFormGroup {
    return this._base.formGroupContext;
  }

  counties?: PostalAddressFormPortugalComponentCountyModel[];
  districts?: PostalAddressFormPortugalComponentDistrictModel[];
  localities?: PostalAddressFormPortugalComponentLocalityModel[];
  streets?: PostalAddressFormPortugalComponentStreetModel[];
  streetSelection?: FormControl<string | null>;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    const { controls } = this.formGroupContext;

    controls.countryCode.setValue("PT");
    controls.postalCode = this._fb.control("", [ Validators.required, POSTAL_CODE_VALIDATORFN ]);
    controls.districtCode = this._fb.control("", [ Validators.required ]);
    controls.countyCode = this._fb.control("", [ Validators.required ]);
    controls.localityCode = this._fb.control("", [ Validators.required ]);
    controls.streetCode = this._fb.control("", [ Validators.required ]);
    controls.location = this._fb.control("", [ ]);
    controls.doorNumber = this._fb.control("", [ ]);
    controls.floorNumber = this._fb.control("", [ ]);
    controls.appartment = this._fb.control("", [ ]);

    controls.postalCode.valueChanges
      .pipe(takeUntil(this._destroy$))
      .pipe(tap(() => this._postalCodeChanging()))
      .pipe(debounceTime(APP_INPUT_DEBOUNCE_TIME))
      .pipe(filter(() => controls.postalCode!.valid))
      .subscribe((postalCode) => this._postalCodeChanges(postalCode!));
  }

  private _postalCodeChanging(): void {
    delete this.counties;
    delete this.districts;
    delete this.streets;
    delete this.streetSelection;
  }

  private async _postalCodeChanges(postalCode: string): Promise<void> {

    const response = await this._client.search({
      postalCode
    });

    this.counties = response.counties;
    this.districts = response.districts;
    this.localities = response.localities;
    this.streets = response.streets;

    const { controls } = this.formGroupContext;

    if (this.counties.length === 1)
      controls.countyCode!.setValue(this.counties[0].countyCode);

    if (this.districts.length === 1)
      controls.districtCode!.setValue(this.districts[0].districtCode);

    if (this.localities.length === 1)
      controls.localityCode!.setValue(this.localities[0].localityCode);

    if (this.streets.length === 1)
      controls.streetCode!.setValue(this.streets[0].streetCode);
  }
}
