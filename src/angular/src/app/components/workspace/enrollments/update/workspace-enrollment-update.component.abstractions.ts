import { FormControl, FormGroup } from "@angular/forms";

export type WorkspaceEnrollmentUpdateComponentForm = FormGroup<{
  serviceId: FormControl<string | null>;
  facilityId: FormControl<string | null>;
  start: FormControl<string | null>;
  comments: FormControl<string | null>;
  student?: FormGroup<{
    name: FormControl<string | null>;
    birth: FormControl<string | null>;
  }>;
}>;

