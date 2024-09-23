import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { Filiation } from "@app/app.enums";
import { PostalAddressFormGroup } from "@app/components/sui/postal-address-form/sui-postal-address-form.component.abstractions";

export type WorkspaceEnrollmentUpdateComponentForm = FormGroup<{
  serviceId: FormControl<string | null>;
  facilityId?: FormControl<string | null>;
  facilityIds?: FormArray<FormControl<string | null>>;
  start: FormControl<string | null>;
  comments: FormControl<string | null>;
  guardian?: WorkspaceEnrollmentUpdateComponentGuardianForm;
  filiation?: WorkspaceEnrollmentUpdateComponentFiliationForm;
  student?: WorkspaceEnrollmentUpdateComponentStudentForm;
}>;

export type WorkspaceEnrollmentUpdateComponentGuardianForm = FormGroup<{
  name: FormControl<string | null>;
  birth: FormControl<string | null>;
  nationality: FormControl<string | null>;
  birthplace?: FormControl<string | null>;
  citizenCardNumber: FormControl<string | null>;
  citizenCardExpiration: FormControl<string | null>;
  taxNumber: FormControl<string | null>;
  socialSecurityNumber: FormControl<string | null>;
  nationalHealthcareNumber: FormControl<string | null>;
  emailAddress: FormControl<string | null>;
  mobilePhoneNumber: FormControl<string | null>;
  homePhoneNumber: FormControl<string | null>;
  workPhoneNumber: FormControl<string | null>;
  residence?: PostalAddressFormGroup;
}>;

export type WorkspaceEnrollmentUpdateComponentFiliationForm = FormArray<FormGroup<{
  filiation: FormControl<string | null>;
  name: FormControl<string | null>;
  birth: FormControl<string | null>;
  nationality: FormControl<string | null>;
  birthplace?: FormControl<string | null>;
  citizenCardNumber: FormControl<string | null>;
  citizenCardExpiration: FormControl<string | null>;
  taxNumber: FormControl<string | null>;
  socialSecurityNumber: FormControl<string | null>;
  nationalHealthcareNumber: FormControl<string | null>;
  emailAddress: FormControl<string | null>;
  mobilePhoneNumber: FormControl<string | null>;
  homePhoneNumber: FormControl<string | null>;
  workPhoneNumber: FormControl<string | null>;
  residence?: PostalAddressFormGroup;
}>>;

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
  pediatrist: FormControl<string | null>;
  protectionService: FormControl<string | null>;
  protectionServiceEnabled: FormControl<boolean | null>;
  protectionServiceOfficer: FormControl<string | null>;
  protectionServiceOfficerPhoneNumber: FormControl<string | null>;
  residence?: PostalAddressFormGroup;
}>;

