import { Component, inject, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { SuiModalComponent } from "@app/components/sui/modal/sui-modal.component";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helper";
import { badRequestOrConflict } from "@app/helpers/service.helper";
import { WorkspaceServiceService } from "@app/services/workspace/services/workspace-service.service";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ ReactiveFormsModule, RouterLink, SuiFormGroupComponent, SuiModalComponent ],
  selector: "app-workspace-service-update",
  standalone: true,
  templateUrl: "workspace-service-update.component.html"
})
export class WorkspaceServiceUpdateComponent implements OnDestroy, OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _fb = inject(FormBuilder);
  private readonly _loadingOverlay = inject(LoadingOverlay);
  private readonly _router = inject(Router);
  private readonly _services = inject(WorkspaceServiceService);

  private _serviceId?: string;
  private _serviceRowVersionId?: string;

  @ViewChild("success") success!: SuiModalComponent;

  readonly form = this._fb.group({
    code: this._fb.control("", [ Validators.maxLength(16), Validators.required ]),
    name: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
    description: this._fb.control("", [ Validators.maxLength(4096) ])
  });

  readonly successActions: SuiModalComponentAction[] = [{
    fn: () => this._router.navigate([ "/workspace/services" ]),
    label: $localize `:@@workspace-service-update-success-modal-primary:Go back to search`,
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
        this._serviceId = model.serviceId;
        this._serviceRowVersionId = model.serviceRowVersionId;

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

      const response = await this._services.submitUpdate({
        serviceId: this._serviceId,
        serviceRowVersionId: this._serviceRowVersionId,
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
