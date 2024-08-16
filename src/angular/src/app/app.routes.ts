import { Route, Routes } from '@angular/router';
import { Permission } from '@app/app.enums';
import { ErrorComponent } from '@app/components/error/error.component';
import { SignInComponent } from '@app/components/sign-in/sign-in.component';
import { WorkspaceEnrollmentSearchComponent } from '@app/components/workspace/enrollments/search/workspace-enrollment-search.component';
import { WorkspaceEnrollmentUpdateEnrollmentComponent } from '@app/components/workspace/enrollments/update/enrollment/workspace-enrollment-update-enrollment.component';
import { WorkspaceEnrollmentUpdateStudentComponent } from '@app/components/workspace/enrollments/update/student/workspace-enrollment-update-student.component';
import { WorkspaceEnrollmentUpdateComponent } from '@app/components/workspace/enrollments/update/workspace-enrollment-update.component';
import { WorkspaceHomeComponent } from '@app/components/workspace/home/workspace-home.component';
import { WorkspaceComponent } from '@app/components/workspace/workspace.component';
import { authorize, bootstrap } from '@app/helpers/route.helpers';

export const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "workspace"
  },
  {
    path: "error",
    component: ErrorComponent
  },
  {
    path: "",
    canActivate: [ bootstrap ],
    children: [
      {
        path: "sign-in",
        title: $localize `:@@app-sign-in:Sign in`,
        component: SignInComponent
      },
      {
        path: "workspace",
        title: $localize `:@@app-workspace:Workspace`,
        component: WorkspaceComponent,
        canActivate: [ authorize([ Permission.Workspace ]) ],
        children: [
          {
            path: "",
            pathMatch: "full",
            title: $localize `:@@app-workspace-home:Workspace`,
            component: WorkspaceHomeComponent
          },
          {
            path: "enrollments",
            canActivate: [ authorize([ Permission.WorkspaceEnrollment ]) ],
            children: [
              {
                path: "",
                pathMatch: "full",
                title: $localize `:@@app-workspace-enrollment-search:Enrollments`,
                component: WorkspaceEnrollmentSearchComponent,
                resolve: ({ model: WorkspaceEnrollmentSearchComponent.model })
              },
              {
                path: ":enrollmentId",
                title: $localize `:@@app-workspace-enrollment-update:Enrollment`,
                component: WorkspaceEnrollmentUpdateComponent,
                resolve: ({ model: WorkspaceEnrollmentUpdateComponent.model }),
                children: [
                  {
                    path: "",
                    pathMatch: "full",
                    component: WorkspaceEnrollmentUpdateEnrollmentComponent
                  },
                  {
                    path: "student",
                    pathMatch: "full",
                    component: WorkspaceEnrollmentUpdateStudentComponent
                  }
                ]
              }
            ]
          }
        ]
      }
    ]
  }
];
