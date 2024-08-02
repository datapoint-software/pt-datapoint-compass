import { FormArray, FormControl, FormGroup } from "@angular/forms";

export type WorkspaceEnrollmentUpdateForm = FormGroup<{
  service: FormControl<string | null>;
  facility: FormControl<string | null>;
  plan: FormControl<string | null>;
  start: FormControl<string | null>;
  student?: FormGroup<{
    name: FormControl<string | null>;
    birth: FormControl<string | null>;
    nationality: FormControl<string | null>;
    birthplace: FormControl<string | null>;
    streetAddress: FormControl<string | null>;
    county: FormControl<string | null>;
    citizenNumber: FormControl<string | null>;
    socialSecurityNumber: FormControl<string | null>;
    taxNumber: FormControl<string | null>;
  }>;
  parents: FormGroup<{
    housing: FormControl<string | null>;
    maritalStatus: FormControl<string | null>;
    guardian: FormControl<string | null>;
    parents: FormArray<FormGroup<{
      name: FormControl<string | null>;
      birth: FormControl<string | null>;
      nationality: FormControl<string | null>;
      birthplace: FormControl<string | null>;
      education: FormControl<string | null>;
      employment: FormGroup<{
        business: FormControl<string | null>;
        county: FormControl<string | null>;
        start: FormControl<string | null>;
        lunch: FormControl<string | null>;
        finish: FormControl<string | null>;
      }>;
    }>>;
  }>;
  familyMembers: FormGroup<{
    monitor: FormGroup<{
      entity: FormControl<string | null>;
      name: FormControl<string | null>;

    }>;
    members: FormArray<FormGroup<{
      name: FormControl<string | null>;
      kinship: FormControl<string | null>;
      education: FormControl<string | null>;
      birth: FormControl<string | null>;
      occupation: FormControl<string | null>;
      employmentStatus: FormControl<string | null>;
      comment: FormControl<string | null>;
    }>>;
  }>;
  guardian: FormGroup<{
    name: FormControl<string | null>;
    birth: FormControl<string | null>;
    nationality: FormControl<string | null>;
    birthplace: FormControl<string | null>;
    education: FormControl<string | null>;
    employment: FormGroup<{
      business: FormControl<string | null>;
      county: FormControl<string | null>;
      emailAddress: FormControl<string | null>;
      phoneNumber: FormControl<string | null>;
      start: FormControl<string | null>;
      lunch: FormControl<string | null>;
      finish: FormControl<string | null>;

    }>;
  }>;
  services: FormGroup<{
    extra: FormControl<boolean | null>;
    extension: FormGroup<{
      monday: FormControl<boolean | null>;
      tuesday: FormControl<boolean | null>;
      wednesday: FormControl<boolean | null>;
      thursday: FormControl<boolean | null>;
      friday: FormControl<boolean | null>;

    }>;
    camps: FormArray<FormGroup<{
      id: FormControl<string | null>;
      enabled: FormControl<boolean | null>;
      from: FormControl<string | null>;
      until: FormControl<string | null>;
    }>>;
    feeding: FormControl<string | null>;
    transportation: FormGroup<{
      streetAddress: FormControl<string | null>;
      days: FormGroup<{
        monday: FormControl<boolean | null>;
        tuesday: FormControl<boolean | null>;
        wednesday: FormControl<boolean | null>;
        thursday: FormControl<boolean | null>;
        friday: FormControl<boolean | null>;

      }>;
    }>;
  }>;
}>
