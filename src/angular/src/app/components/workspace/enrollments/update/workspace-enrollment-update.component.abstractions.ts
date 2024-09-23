import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { PostalAddressFormGroup } from "@app/components/sui/postal-address-form/sui-postal-address-form.component.abstractions";

export type WorkspaceEnrollmentUpdateComponentForm = FormGroup<{
  serviceId: FormControl<string | null>;
  facilityId?: FormControl<string | null>;
  facilityIds?: FormArray<FormControl<string | null>>;
  start: FormControl<string | null>;
  comments: FormControl<string | null>;
  student?: WorkspaceEnrollmentUpdateComponentStudentForm;
}>;

export type WorkspaceEnrollmentUpdateComponentStudentForm = FormGroup<{
  name: FormControl<string | null>;
  birth: FormControl<string | null>;
  nationality: FormControl<string | null>;
  birthplace?: FormControl<string | null>;
  citizenCardNumber: FormControl<string | null>;
  citizenCardExpiration: FormControl<string | null>;
  taxNumber: FormControl<string | null>;
  socialSecurityNumber: FormControl<string | null>;
  nationalHealthcareNumber: FormControl<string | null>;

  residence?: PostalAddressFormGroup;
}>;

