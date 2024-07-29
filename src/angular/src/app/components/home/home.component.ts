import { Component, inject, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IdentityKind } from "@app/app.enums";
import { Identity } from "@app/features/identity/identity.feature";

@Component({
  selector: "app-home",
  standalone: true,
  templateUrl: "home.component.html"
})
export class HomeComponent implements OnInit {

  private readonly _identity: Identity = inject(Identity);
  private readonly _router: Router = inject(Router);

  ngOnInit(): void {
    switch (this._identity.kind!) {
      case IdentityKind.Employee:
        this._router.navigate([ "/workspace" ]);
        break;

      default:
        this._router.navigate([ "/error" ]);
        break;
    }
  }
}
