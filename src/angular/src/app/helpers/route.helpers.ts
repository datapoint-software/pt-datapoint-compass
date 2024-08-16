import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { Permission } from "@app/app.enums";
import { IdentityFeature } from "@app/features/identity/identity.feature";

export const authorize = (permissions: Permission[]): CanActivateFn =>

  (async () => {

    const identity = inject(IdentityFeature);
    const router = inject(Router);

    if (!identity.refreshed)
      await identity.refresh();

    if (!identity.anonymous) {

      const allowed = permissions
        .filter(p => identity.permissions.has(p))
        .length === permissions.length;

      if (allowed)
        return true;

      return router.createUrlTree([
        "/error"
      ], {
        queryParams: {
          status: "403",
          context: "navigation"
        }
      });
    }

    return router.createUrlTree([
      "/sign-in"
    ], {
      queryParams: {
        redirectUrl: document.location.pathname
      }
    });
  });

export const bootstrap: CanActivateFn = async () => {

  const identity = inject(IdentityFeature);

  if (!identity.refreshed)
    await identity.refresh();

  return true;
};
