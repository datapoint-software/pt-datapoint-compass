import { NgComponentOutlet } from "@angular/common";
import { Component, Input, OnDestroy, OnInit, Type } from "@angular/core";
import { PostalAddressFormGroup } from "@app/components/sui/postal-address-form/sui-postal-address-form.component.abstractions";
import { Subject } from "rxjs";

@Component({
  imports: [ NgComponentOutlet ],
  selector: "app-sui-postal-address-form",
  standalone: true,
  templateUrl: "sui-postal-address-form.component.html"
})
export class SuiPostalAddressFormComponent implements OnDestroy, OnInit {

  private readonly _destroy$: Subject<true> = new Subject();

  @Input({ required: true }) formGroupContext!: PostalAddressFormGroup;

  componentConstructor!: Type<unknown>;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    import("./portugal/sui-postal-address-form-portugal.component")
      .then(m => this.componentConstructor = m.SuiPostalAddressFormPortugalComponent);

  }

  resetControls(): Partial<{
    countryCode: string | null;
    districtCode: string | null;
    countyCode: string | null;
    localityCode: string | null;
    areaCode: string | null;
    areaName: string | null;
    streetCode: string | null;
    lines: Array<string | null>;
    appartment: string | null;
    doorNumber: string | null;
    floorNumber: string | null;
  }> {
    return this.formGroupContext.value;
  }

}
