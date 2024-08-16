import { FormControl, FormGroup } from "@angular/forms";

export type WorkspaceEnrollmentSearchComponentForm = FormGroup<{
  filter: FormControl<string | null>;
  serviceId: FormControl<string | null>;
  facilityId: FormControl<string | null>;
  status: FormControl<string | null>;
}>;
