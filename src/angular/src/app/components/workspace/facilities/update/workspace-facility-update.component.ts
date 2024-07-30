import { Component, inject, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helper";
import { badRequestOrConflict } from "@app/helpers/service.helper";
import { WorkspaceFacilityService } from "@app/services/workspace/facilities/workspace-facility.service";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ ReactiveFormsModule, RouterLink, SuiFormGroupComponent, SuiModalComponent ],
  selector: "app-workspace-facility-update",
  standalone: true,
  templateUrl: "workspace-facility-update.component.html"
})
export class WorkspaceFacilityUpdateComponent implements OnDestroy, OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _facilities = inject(WorkspaceFacilityService);
  private readonly _fb = inject(FormBuilder);
  private readonly _loadingOverlay = inject(LoadingOverlay);
  private readonly _router = inject(Router);

  private _facilityId?: string;
  private _facilityRowVersionId?: string;

  @ViewChild("success") success!: SuiModalComponent;

  readonly form = this._fb.group({
    code: this._fb.control("", [ Validators.maxLength(16), Validators.required ]),
    name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
    description: this._fb.control("", [ Validators.maxLength(4096) ])
  });

  readonly successActions: SuiModalComponentAction[] = [{
    fn: () => this._router.navigate([ "/workspace/facilities" ]),
    label: $localize `:@@workspace-facility-update-success-modal-primary:Go back to search`,
    type: "primary"
  }];

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this._facilityId = model.facilityId;
        this._facilityRowVersionId = model.facilityRowVersionId;

        if (model.form) {
          this.form.reset(model.form);
          this.form.controls.code.disable();
        }
      });
  }

  submit(): void {

    if (this.form.invalid)
      return;

    this._loadingOverlay.merge(async () => {

      const response = await this._facilities.submitUpdate({
        facilityId: this._facilityId,
        facilityRowVersionId: this._facilityRowVersionId,
        form: fromValueOf(this.form)
      })

        .catch(badRequestOrConflict((response) => {
          applyErrorResponse(this.form, response);
          return null;
        }));

      if (!response)
        return;

      this.success.open();
    });
  }
}
