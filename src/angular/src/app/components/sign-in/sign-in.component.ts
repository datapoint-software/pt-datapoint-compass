import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { DataTogglePasswordDirective } from "@app/directives/data-toggle-password/data-toggle-password.directive";
import { IdentityFeature } from "@app/features/identity/identity.feature";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";
import { badRequestOrConflict } from "@app/helpers/api.helpers";
import { applyErrorResponse, fromValueOf } from "@app/helpers/form.helpers";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DataTogglePasswordDirective, ReactiveFormsModule, SuiFormGroupComponent ],
  selector: "app-sign-in",
  standalone: true,
  templateUrl: "sign-in.component.html"
})
export class SignInComponent implements OnDestroy, OnInit {

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _identityFeature: IdentityFeature = inject(IdentityFeature);
  private readonly _loadingOverlayFeature: LoadingOverlayFeature = inject(LoadingOverlayFeature);
  private readonly _router: Router = inject(Router);

  redirectUrl!: string;

  form = this._fb.group({
    emailAddress: this._fb.control("", [ Validators.maxLength(128), Validators.required ]),
    password: this._fb.control("", [ Validators.maxLength(1024), Validators.required ]),
    rememberMe: this._fb.control(false, [ Validators.required ])
  });

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.queryParamMap
      .pipe(takeUntil(this._destroy$))
      .subscribe((params) => {
        this.redirectUrl = params.get("redirect") ?? "/";
      });
  }

  signIn(): Promise<void> {
    return this._loadingOverlayFeature.enqueueWhile(() => {
      return this._identityFeature.signIn(fromValueOf(this.form))
        .then(() => {
          this._router.navigateByUrl(this.redirectUrl);
        })
        .catch(badRequestOrConflict((response) => {
          applyErrorResponse(this.form, response);
        }))
    });
  }
}
