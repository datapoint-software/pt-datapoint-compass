import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { DataTogglePasswordDirective } from "@app/directives/data-toggle-password/data-toggle-password.directive";
import { Identity } from "@app/features/identity/identity.feature";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { conflict } from "@app/helpers/service.helper";
import { IdentityService } from "@app/services/identities/identity.service";
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
  private readonly _identities: IdentityService = inject(IdentityService);
  private readonly _identity: Identity = inject(Identity);
  private readonly _loadingOverlay: LoadingOverlay = inject(LoadingOverlay);
  private readonly _router: Router = inject(Router);

  readonly form = this._fb.group({
    emailAddress: this._fb.control("", [ Validators.email, Validators.maxLength(128), Validators.required ]),
    password: this._fb.control("", [ Validators.maxLength(1024), Validators.required ]),
    rememberMe: this._fb.control(false, [ Validators.required ])
  });

  redirectUrl: string = "/";

  signIn(): void {

    if (this.form.invalid)
      return;

    this._loadingOverlay.merge(async () => {

      const response = await this._identities.signIn({
        emailAddress: this.form.value.emailAddress!,
        password: this.form.value.password!,
        rememberMe: this.form.value.rememberMe!
      })

        .catch(conflict((response) => this._signInError()));

      if (!response)
        return;

      this._identity.authenticate(response);

      this._router.navigateByUrl(this.redirectUrl);
    });
  }

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    this._activatedRoute.queryParamMap
      .pipe(takeUntil(this._destroy$))
      .subscribe((qs) => {
        this.redirectUrl = qs.get("redirectUrl") ?? "/";
      });
  }

  private _signInError(): void {
    this.form.setErrors({ authentication: true });
  }
}
