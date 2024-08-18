import { provideHttpClient } from "@angular/common/http";
import { ApplicationConfig, ErrorHandler, provideZoneChangeDetection } from "@angular/core";
import { provideAnimations } from "@angular/platform-browser/animations";
import { provideRouter } from "@angular/router";
import { WorkspaceEnrollmentSearchComponentClient } from "@app/api/components/workspace/enrollments/search/workspace-enrollment-search-component.client";
import { WorkspaceEnrollmentUpdateComponentClient } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client";
import { WorkspaceHomeComponentClient } from "@app/api/components/workspace/home/workspace-home-component.client";
import { CountryClient } from "@app/api/countries/country.client";
import { DistrictClient } from "@app/api/districts/district.client";
import { IdentityFeatureClient } from "@app/api/features/identity/identity-feature.client";
import { AppErrorHandler } from "@app/app.handlers";
import { routes } from "@app/app.routes";
import { IdentityFeature } from "@app/features/identity/identity.feature";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";

export const appConfig: ApplicationConfig = {
  providers: [

    // Core
    provideAnimations(),
    provideHttpClient(),
    provideRouter(routes),
    provideZoneChangeDetection({ eventCoalescing: true }),

    { useClass: AppErrorHandler, provide: ErrorHandler },

    // Clients
    CountryClient,
    DistrictClient,
    IdentityFeatureClient,
    WorkspaceEnrollmentSearchComponentClient,
    WorkspaceEnrollmentUpdateComponentClient,
    WorkspaceHomeComponentClient,

    // Features
    IdentityFeature,
    LoadingOverlayFeature
  ]
};
