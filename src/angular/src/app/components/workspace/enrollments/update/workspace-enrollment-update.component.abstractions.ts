import { FormArray, FormControl, FormGroup } from "@angular/forms";

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
}>;

