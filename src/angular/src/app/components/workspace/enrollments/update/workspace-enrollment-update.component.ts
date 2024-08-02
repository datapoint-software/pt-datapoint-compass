import { Component, inject, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { APP_LOCALE } from "@app/app.constants";
import { Kinship, MaritalStatus, Service } from "@app/app.enums";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { WorkspaceEnrollmentUpdateForm } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component.abstractions";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { optionOf, optionsOf } from "@app/helpers/enum.helpers";
import { KINSHIP_MESSAGES } from "@app/messages/kinship.messages";
import { MARITAL_STATUS_MESSAGES } from "@app/messages/marital-status.messages";
import { SERVICE_MESSAGES } from "@app/messages/service.messages";
import { DocumentKindLabelPipe } from "@app/pipes/document-kind-label/document-kind-label.pipe";
import { DistrictModel } from "@app/services/districts/district.abstractions";
import { DistrictService } from "@app/services/districts/district.service";
import { NationalityModel } from "@app/services/nationalities/nationality.service.abstractions";
import { WorkspaceEnrollmentFacilityModel, WorkspaceEnrollmentUpdateFormModel } from "@app/services/workspace/enrollments/workspace-enrollment.service.abstractions";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DocumentKindLabelPipe, ReactiveFormsModule, RouterLink, SuiFormGroupComponent, SuiModalComponent ],
  selector: "app-workspace-enrollment-update",
  standalone: true,
  templateUrl: "workspace-enrollment-update.component.html"
})
export class WorkspaceEnrollmentUpdateComponent implements OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _districts = inject(DistrictService);
  private readonly _fb = inject(FormBuilder);
  private readonly _loadingOverlay = inject(LoadingOverlay);

  readonly form: WorkspaceEnrollmentUpdateForm = this._fb.group({
    service: this._fb.control(null as string | null, [ Validators.required ]),
    facility: this._fb.control("", [ Validators.required ]),
    plan: this._fb.control("", [ Validators.required ]),
    start: this._fb.control("", [ Validators.required ]),
    familyMembers: this._fb.group({
      monitor: this._fb.group({
        entity: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
        name: this._fb.control("", [ Validators.maxLength(128), Validators.required ])
      }),
      members: this._fb.array([] as FormGroup<{
        name: FormControl<string | null>;
        kinship: FormControl<string | null>;
        education: FormControl<string | null>;
        birth: FormControl<string | null>;
        occupation: FormControl<string | null>;
        employmentStatus: FormControl<string | null>;
        comment: FormControl<string | null>;
      }>[])
    })
  });

  districts = new Map<string, DistrictModel[]>();
  facilities!: WorkspaceEnrollmentFacilityModel[];
  nationalities!: NationalityModel[];

  kinships = optionsOf(Kinship)
    .map((id) => ({ id, name: KINSHIP_MESSAGES.get(id)! }))
    .sort((a, b) => a.name.localeCompare(b.name));

  maritalStatuses = optionsOf(MaritalStatus)
    .map((id) => ({ id, name: MARITAL_STATUS_MESSAGES.get(id)! }))
    .sort((a, b) => a.name.localeCompare(b.name));

  services = optionsOf(Service)
    .map((id) => ({ id, name: SERVICE_MESSAGES.get(id)! }))
    .sort((a, b) => a.name.localeCompare(b.name));

  plans = new Map([[
    Service.ActivityCenter, [
    { code: "DF", name: "Normal" }
  ]], [
    Service.Childcare, [
    { code: "MC", name: "Mensalidade completa com almoço" },
    { code: "ML", name: "Mensalidade com lanche" },
    { code: "MR", name: "Mensalidade com refeitório social"}
  ]]]);

  addExtraServicesControls() {
    const extraServices = this._fb.group({
      extra: this._fb.control(false, []),
      extension: this._fb.group({
        monday: this._fb.control(false, []),
        tuesday: this._fb.control(false, []),
        wednesday: this._fb.control(false, []),
        thursday: this._fb.control(false, []),
        friday: this._fb.control(false, [])
      }),
      camps: this._fb.array([
        this._fb.group({
          id: this._fb.control("86c8daa4-c313-48e2-9d52-7ba109984138", [ Validators.required ]),
          enabled: this._fb.control(false, []),
          from: this._fb.control("", [ Validators.required ]),
          until: this._fb.control("", [])
        }),
        this._fb.group({
          id: this._fb.control("abf34d03-da01-455c-97f1-fca74d8f0514", [ Validators.required ]),
          enabled: this._fb.control(false, []),
          from: this._fb.control("", [ Validators.required ]),
          until: this._fb.control("", [])
        }),
        this._fb.group({
          id: this._fb.control("4992413a-5175-4299-a6a0-b012faaacd9a", [ Validators.required ]),
          enabled: this._fb.control(false, []),
          from: this._fb.control("", [ Validators.required ]),
          until: this._fb.control("", [])
        })
      ]),
      transportation: this._fb.group({
        streetAddress: this._fb.control("", [ Validators.required ]),
        days: this._fb.group({
          monday: this._fb.control(false, []),
          tuesday: this._fb.control(false, []),
          wednesday: this._fb.control(false, []),
          thursday: this._fb.control(false, []),
          friday: this._fb.control(false, [])
        })
      })
    });

    this.form.addControl("extraServices", extraServices);
  }

  addStudentControls() {

    const student = this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control("", [ Validators.required ]),
      birthplace: this._fb.control("", [ Validators.required ]),
      streetAddress: this._fb.control("", [ Validators.required ]),
      county: this._fb.control("", [ Validators.required ]),
      citizenNumber: this._fb.control("", [ Validators.required ]),
      socialSecurityNumber: this._fb.control("", []),
      taxNumber: this._fb.control("", []),
    });

    this.form.addControl("student", student);

    student.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((nationality) => this._nationalityChanges(student, nationality));
  }

  addFamilyMemberControls() {

    const familyMember = this._fb.group({
      name: this._fb.control("", [ Validators.minLength(128), Validators.required ]),
      kinship: this._fb.control("", [ Validators.required ]),
      education: this._fb.control("", [ Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      occupation: this._fb.control("", [ Validators.required ]),
      employmentStatus: this._fb.control("", [ Validators.required ]),
      comment: this._fb.control("", [ Validators.maxLength(4096) ])
    });

    this.form.controls.familyMembers.controls.members.push(familyMember);
  }

  addGuardianControls() {
    const guardian = this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control("", [ Validators.required ]),
      birthplace: this._fb.control("", [ Validators.required ]),
      education: this._fb.control("", [ Validators.required ]),
      employment: this._fb.group({
        business: this._fb.control("", [ Validators.required ]),
        county: this._fb.control("", [ Validators.required ]),
        emailAddress: this._fb.control("", []),
        phoneNumber: this._fb.control("", []),
        start: this._fb.control("", []),
        lunch: this._fb.control("", []),
        finish: this._fb.control("", [])
      })
    });

    guardian.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((nationality) => this._nationalityChanges(guardian, nationality));

    this.form.addControl("guardian", guardian);
  }

  addParentSectionControls() {

    const parent = this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control("", [ Validators.required ]),
      birthplace: this._fb.control("", [ Validators.required ]),
      education: this._fb.control("", [ Validators.required ]),
      employment: this._fb.group({
        business: this._fb.control("", [ Validators.required ]),
        county: this._fb.control("", [ Validators.required ]),
        start: this._fb.control("", []),
        lunch: this._fb.control("", []),
        finish: this._fb.control("", [])
      })
    });

    parent.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((nationality) => this._nationalityChanges(parent, nationality));

    const parents = this._fb.group({
      housing: this._fb.control("", [ Validators.required ]),
      maritalStatus: this._fb.control("", [ Validators.required ]),
      guardian: this._fb.control("", [ Validators.required ]),
      parents: this._fb.array([ parent ])
    });

    this.form.addControl("parents", parents);

  }

  addParentControls() {

    const parent = this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control("", [ Validators.required ]),
      birthplace: this._fb.control("", [ Validators.required ]),
      education: this._fb.control("", [ Validators.required ]),
      employment: this._fb.group({
        business: this._fb.control("", [ Validators.required ]),
        county: this._fb.control("", [ Validators.required ]),
        start: this._fb.control("", []),
        lunch: this._fb.control("", []),
        finish: this._fb.control("", [])
      })
    });

    parent.controls.nationality.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((nationality) => this._nationalityChanges(parent, nationality));

    this.form.controls.parents!.controls.parents.push(parent);
  }

  getServicePlans(): ({ code: string; name: string })[] {

    const service = optionOf(Service, this.form.controls.service.value);

    if (!service)
      return [];

    return this.plans.get(service) ?? [];
  }

  ngOnInit(): void {

    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model, nationalities }) => {
        this.facilities = model.facilities;
        this.nationalities = nationalities;
      });

    this.form.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((enrollment) => this._formChanges(enrollment));

    this.form.controls.plan.disable();

    this.form.controls.service.valueChanges
      .pipe(takeUntil(this._destroy$))
      .subscribe((service) => this._serviceChanges(this.form, optionOf(Service, service)));
  }

  private _formChanges(enrollment: WorkspaceEnrollmentUpdateForm["value"]): void {

  }

  private async _nationalityChanges(formGroup: FormGroup, nationality: string | null): Promise<void> {

    formGroup.removeControl("birthplace");

    if (!nationality)
      return;

    let districts = this.districts.get(nationality);

    if (!districts) {
      await this._loadingOverlay.merge(async () => {

        districts = await this._districts.getAll({
          countryCode: nationality,
          locale: APP_LOCALE
        })

        this.districts.set(nationality, districts);
      });
    }

    if (districts!.length > 0)
      formGroup.addControl("birthplace", this._fb.control("", [ Validators.required ]));
  }

  private _serviceChanges(form: FormGroup, service: Service | null): void {
    form.get("plan")?.enable();
  }
}
