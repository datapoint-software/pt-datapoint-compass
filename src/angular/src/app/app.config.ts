import { provideHttpClient } from "@angular/common/http";
import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideAnimations } from "@angular/platform-browser/animations";
import { PreloadAllModules, provideRouter, withPreloading } from "@angular/router";
import { routes } from "@app/app.routes";
import { Identity } from "@app/features/identity/identity.feature";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { IdentityService } from "@app/services/identities/identity.service";
import { NationalityService } from "@app/services/nationalities/nationality.service";
import { WorkspaceEnrollmentService } from "@app/services/workspace/enrollments/workspace-enrollment.service";
import { WorkspaceFacilityService } from "@app/services/workspace/facilities/workspace-facility.service";
import { WorkspaceServiceService } from "@app/services/workspace/services/workspace-service.service";

export const appConfig: ApplicationConfig = {
  providers: [

    // Core
    provideAnimations(),
    provideHttpClient(),
    provideRouter(routes, withPreloading(PreloadAllModules)),
    provideZoneChangeDetection({ eventCoalescing: true }),

    // Features
    Identity,
    LoadingOverlay,

    // Services
    IdentityService,
    NationalityService,
    WorkspaceEnrollmentService,
    WorkspaceFacilityService,
    WorkspaceServiceService
  ]
};
