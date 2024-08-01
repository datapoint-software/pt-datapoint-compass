import { Component, inject, OnInit } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { Service } from "@app/app.enums";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { optionsOf } from "@app/helpers/enum.helpers";
import { SERVICE_MESSAGES } from "@app/messages/service.messages";
import { DocumentKindLabelPipe } from "@app/pipes/document-kind-label/document-kind-label.pipe";
import { WorkspaceEnrollmentFacilityModel } from "@app/services/workspace/enrollments/workspace-enrollment.service.abstractions";
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
  private readonly _fb = inject(FormBuilder);

  readonly form = this._fb.group({
    service: this._fb.control("", [ Validators.required ]),
    facility: this._fb.control("", [ Validators.required ]),
    student: this._fb.group({
      name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
      birth: this._fb.control("", [ Validators.required ]),
      nationality: this._fb.control("", [ Validators.required ]),
      birthplace: this._fb.control("", [ Validators.required ]),
      streetAddress: this._fb.control("", [ Validators.required ]),
      county: this._fb.control("", [ Validators.required ]),
      citizenNumber: this._fb.control("", [ Validators.required ]),
      socialSecurityNumber: this._fb.control("", []),
      taxNumber: this._fb.control("", []),
    }),
    parents: this._fb.group({
      housing: this._fb.control("", [ Validators.required ]),
      maritalStatus: this._fb.control("", [ Validators.required ]),
      guardian: this._fb.control("", [ Validators.required ]),
      parents: this._fb.array([
        this._fb.group({
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
        }),
        this._fb.group({
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
        })
      ])
    }),
    familyMembers: this._fb.group({
      monitor: this._fb.group({
        entity: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
        name: this._fb.control("", [ Validators.maxLength(128), Validators.required ])
      }),
      members: this._fb.array([
        this._fb.group({
          name: this._fb.control("", [ Validators.minLength(128), Validators.required ]),
          kinship: this._fb.control("", [ Validators.required ]),
          education: this._fb.control("", [ Validators.required ]),
          birth: this._fb.control("", [ Validators.required ]),
          occupation: this._fb.control("", [ Validators.required ]),
          employmentStatus: this._fb.control("", [ Validators.required ]),
          comment: this._fb.control("", [ Validators.maxLength(4096) ])
        }),
        this._fb.group({
          name: this._fb.control("", [ Validators.minLength(128), Validators.required ]),
          kinship: this._fb.control("", [ Validators.required ]),
          education: this._fb.control("", [ Validators.required ]),
          birth: this._fb.control("", [ Validators.required ]),
          occupation: this._fb.control("", [ Validators.required ]),
          employmentStatus: this._fb.control("", [ Validators.required ]),
          comment: this._fb.control("", [ Validators.maxLength(4096) ])
        }),
        this._fb.group({
          name: this._fb.control("", [ Validators.minLength(128), Validators.required ]),
          kinship: this._fb.control("", [ Validators.required ]),
          education: this._fb.control("", [ Validators.required ]),
          birth: this._fb.control("", [ Validators.required ]),
          occupation: this._fb.control("", [ Validators.required ]),
          employmentStatus: this._fb.control("", [ Validators.required ]),
          comment: this._fb.control("", [ Validators.maxLength(4096) ])
        }),
        this._fb.group({
          name: this._fb.control("", [ Validators.minLength(128), Validators.required ]),
          kinship: this._fb.control("", [ Validators.required ]),
          education: this._fb.control("", [ Validators.required ]),
          birth: this._fb.control("", [ Validators.required ]),
          occupation: this._fb.control("", [ Validators.required ]),
          employmentStatus: this._fb.control("", [ Validators.required ]),
          comment: this._fb.control("", [ Validators.maxLength(4096) ])
        })
      ])
    }),
    guardian: this._fb.group({
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
    }),
    services: this._fb.group({
      extra: this._fb.control(false, []),
      lunch: this._fb.control("", [ Validators.required ]),
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
    })
  });

  facilities!: WorkspaceEnrollmentFacilityModel[];

  services = optionsOf(Service).map((id) => ({
    id,
    name: SERVICE_MESSAGES.get(id)!
  }));

  ngOnInit(): void {

    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this.facilities = model.facilities;
      });

  }

}
