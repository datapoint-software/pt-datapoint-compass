import { FormArray, FormControl, FormGroup } from "@angular/forms"

export type PostalAddressFormGroup = FormGroup<{
  countryCode: FormControl<string | null>;
  postalCode?: FormControl<string | null>;
  districtCode?: FormControl<string | null>;
  countyCode?: FormControl<string | null>;
  localityCode?: FormControl<string | null>;
  streetCode?: FormControl<string | null>;
  location?: FormControl<string | null>;
  doorNumber?: FormControl<string | null>;
  floorNumber?: FormControl<string | null>;
  appartment?: FormControl<string | null>;
}>
