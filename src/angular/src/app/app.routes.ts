import { Routes } from "@angular/router";
import { Permission } from "@app/app.enums";
import { ErrorComponent } from "@app/components/error/error.component";
import { HomeComponent } from "@app/components/home/home.component";
import { SignInComponent } from "@app/components/sign-in/sign-in.component";
import { WorkspaceEnrollmentSearchComponent } from "@app/components/workspace/enrollments/search/workspace-enrollment-search.component";
import { WorkspaceEnrollmentUpdateComponent } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component";
import { workspaceEnrollmentUpdateComponentResolveFn } from "@app/components/workspace/enrollments/update/workspace-enrollment-update.component.resolvers";
import { WorkspaceFacilitySearchComponent } from "@app/components/workspace/facilities/search/workspace-facility-search.component";
import { workspaceFacilitySearchComponentResolveFn } from "@app/components/workspace/facilities/search/workspace-facility-search.component.resolvers";
import { WorkspaceFacilityUpdateComponent } from "@app/components/workspace/facilities/update/workspace-facility-update.component";
import { workspaceFacilityUpdateComponentResolveFn } from "@app/components/workspace/facilities/update/workspace-facility-update.component.resolvers";
import { WorkspaceServiceSearchComponent } from "@app/components/workspace/services/search/workspace-service-search.component";
import { workspaceServiceSearchComponentResolveFn } from "@app/components/workspace/services/search/workspace-service-search.component.resolvers";
import { WorkspaceServiceUpdateComponent } from "@app/components/workspace/services/update/workspace-service-update.component";
import { workspaceServiceUpdateComponentResolveFn } from "@app/components/workspace/services/update/workspace-service-update.component.resolvers";
import { WorkspaceComponent } from "@app/components/workspace/workspace.component";
import { identityCanActivateFn } from "@app/guards/identity.guards";
import { signInCanActivateFn } from "@app/guards/sign-in.guards";
import { nationalityArrayResolveFn } from "@app/resolvers/nationality.resolvers";

export const routes: Routes = [
  {
    path: "error",
    component: ErrorComponent
  },
  {
    path: "sign-in",
    canActivate: [ signInCanActivateFn ],
    component: SignInComponent
  },
  {
    path: "",
    pathMatch: "prefix",
    canActivate: [ identityCanActivateFn() ],
    children: [
      {
        path: "",
        pathMatch: "full",
        component: HomeComponent
      },
      {
        path: "workspace",
        canActivate: [ identityCanActivateFn([ Permission.Workspace ])],
        component: WorkspaceComponent,
        children: [
          {
            path: "enrollments",
            canActivate: [ identityCanActivateFn([ Permission.WorkspaceEnrollments ])],
            children: [
              {
                path: "",
                pathMatch: "full",
                component: WorkspaceEnrollmentSearchComponent
              },
              {
                path: "_",
                component: WorkspaceEnrollmentUpdateComponent,
                resolve: ({
                  model: workspaceEnrollmentUpdateComponentResolveFn,
                  nationalities: nationalityArrayResolveFn
                })
              },
              {
                path: ":enrollmentId",
                component: WorkspaceEnrollmentUpdateComponent,
                resolve: ({
                  model: workspaceEnrollmentUpdateComponentResolveFn,
                  nationalities: nationalityArrayResolveFn
                })
              }
            ]
          },
          {
            path: "facilities",
            canActivate: [ identityCanActivateFn([ Permission.WorkspaceFacilities ])],
            children: [
              {
                path: "",
                pathMatch: "full",
                component: WorkspaceFacilitySearchComponent,
                resolve: ({
                  model: workspaceFacilitySearchComponentResolveFn
                })
              },
              {
                path: "_",
                component: WorkspaceFacilityUpdateComponent,
                resolve: ({
                  model: workspaceFacilityUpdateComponentResolveFn
                })
              },
              {
                path: ":facilityId",
                component: WorkspaceFacilityUpdateComponent,
                resolve: ({
                  model: workspaceFacilityUpdateComponentResolveFn
                })
              }
            ]
          },
          {
            path: "services",
            canActivate: [ identityCanActivateFn([ Permission.WorkspaceServices ])],
            children: [
              {
                path: "",
                pathMatch: "full",
                component: WorkspaceServiceSearchComponent,
                resolve: ({
                  model: workspaceServiceSearchComponentResolveFn
                })
              },
              {
                path: "_",
                component: WorkspaceServiceUpdateComponent,
                resolve: ({
                  model: workspaceServiceUpdateComponentResolveFn
                })
              },
              {
                path: ":serviceId",
                component: WorkspaceServiceUpdateComponent,
                resolve: ({
                  model: workspaceServiceUpdateComponentResolveFn
                })
              }
            ]
          }
        ]
      }
    ]
  }
];
