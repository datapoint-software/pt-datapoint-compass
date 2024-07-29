import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { Permission } from "@app/app.enums";
import { Identity } from "@app/features/identity/identity.feature";

export const identityCanActivateFn = (permissions?: Permission[]): CanActivateFn => async () => {

  const identity = inject(Identity)
  const router = inject(Router);

  if (!identity.refreshed)
    await identity.refresh();

  if (identity.anonymous) {
    return router.createUrlTree([
      "/sign-in"
    ], {
      queryParams: {
        redirectUrl: document.location.pathname
      }
    });
  }

  if (permissions) {
    for (const permission of permissions) {
      if (!identity.permissions.has(permission)) {
        return router.createUrlTree([
          "/error",
        ], {
          queryParams: {
            status: 403
          }
        });
      }
    }
  }

  return true;
};
