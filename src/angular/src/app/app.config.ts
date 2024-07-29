import { provideHttpClient } from "@angular/common/http";
import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideAnimations } from "@angular/platform-browser/animations";
import { provideRouter } from "@angular/router";
import { routes } from "@app/app.routes";
import { Identity } from "@app/features/identity/identity.feature";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { IdentityService } from "@app/services/identities/identity.service";

export const appConfig: ApplicationConfig = {
  providers: [

    // Core
    provideAnimations(),
    provideHttpClient(),
    provideRouter(routes),
    provideZoneChangeDetection({ eventCoalescing: true }),

    // Features
    Identity,
    LoadingOverlay,

    // Services
    IdentityService
  ]
};
