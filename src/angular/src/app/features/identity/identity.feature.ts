import { inject, Injectable } from "@angular/core";
import { IdentityKind, Permission } from "@app/app.enums";
import { conflict, unauthorized } from "@app/helpers/service.helper";
import { IdentityService } from "@app/services/identities/identity.service";
import { IdentityModel } from "@app/services/identities/identity.service.abstractions";

@Injectable()
export class Identity {

  private readonly _identities = inject(IdentityService);

  private _refreshTimeoutId?: ReturnType<typeof setTimeout>;

  anonymous: boolean = true;
  id?: string;
  name?: string;
  emailAddress?: string;
  kind?: IdentityKind;
  permissions: Set<Permission> = new Set();
  refreshed: boolean = false;
  expiration: Date | null = null;

  authenticate(model: IdentityModel): void {

    this.anonymous = false;
    this.id = model.id;
    this.name = model.name;
    this.emailAddress = model.emailAddress;
    this.kind = model.kind;
    this.permissions = new Set(model.permissions);
    this.expiration = model.expiration
      ? new Date(model.expiration)
      : null;

    if (this._refreshTimeoutId)
      clearTimeout(this._refreshTimeoutId);

    if (this.expiration) {
      setTimeout(
        () => this.refresh(),
        (this.expiration.getTime() - (new Date()).getTime() - 2500)
      );
    }
  }

  async refresh(): Promise<void> {

    this.refreshed = true;

    const model = await this._identities.refresh()
      .catch((conflict(() => null)))
      .catch((unauthorized(() => null)));

    if (!model)
      return;

    this.authenticate(model);
  }

  reset(): void {

    if (this._refreshTimeoutId)
      clearTimeout(this._refreshTimeoutId);

    this.anonymous = true;
    this.expiration = null;
    this.permissions = new Set();
    this.refreshed = false;

    delete this._refreshTimeoutId;

    delete this.id;
    delete this.name;
    delete this.emailAddress;
    delete this.kind;
  }
}
