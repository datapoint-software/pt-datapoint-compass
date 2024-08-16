import { inject, Injectable } from "@angular/core";
import { IdentityFeatureClient } from "@app/api/features/identity/identity-feature.client";
import { IdentityFeatureModel, IdentityFeatureSignInModel } from "@app/api/features/identity/identity-feature.client.abstractions";
import { IdentityKind, Permission } from "@app/app.enums";

@Injectable()
export class IdentityFeature {

  private readonly _api: IdentityFeatureClient = inject(IdentityFeatureClient);

  private _refreshTimeoutId?: ReturnType<typeof setTimeout>;

  anonymous: boolean = true;
  authenticated: boolean = false;
  emailAddress?: string;
  employee: boolean = false;
  expiration?: Date;
  id?: string;
  kind: IdentityKind = IdentityKind.Anonymous;
  name?: string;
  permissions: Set<Permission> = new Set();
  refreshed: boolean = false;

  async refresh(): Promise<void> {
    const feature = await this._api.refresh();
    this._configure(feature);
  }

  async signIn(model: IdentityFeatureSignInModel): Promise<void> {
    const feature = await this._api.signIn(model);
    this._configure(feature);
  }

  private _configure(feature: IdentityFeatureModel): void {

    if (this._refreshTimeoutId) {
      clearTimeout(this._refreshTimeoutId);
      delete this._refreshTimeoutId;
    }

    this.anonymous = feature.kind === IdentityKind.Anonymous;
    this.authenticated = !this.anonymous;
    this.emailAddress = feature.emailAddress;
    this.employee = feature.kind === IdentityKind.Employee;
    this.expiration = feature.expiration
      ? new Date(feature.expiration)
      : undefined;
    this.id = feature.id;
    this.kind = feature.kind;
    this.name = feature.name;

    this.permissions.clear();

    if (feature.permissions)
      for (const permission of feature.permissions)
        this.permissions.add(permission);

    if (this.expiration) {
      this._refreshTimeoutId = setTimeout(
        this.refresh.bind(this),
        (this.expiration.getTime() - new Date().getTime() - 2500)
      );
    }

    this.refreshed = true;
  }
}
