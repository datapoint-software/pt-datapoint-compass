import { Routes } from "@angular/router";
import { Permission } from "@app/app.enums";
import { ErrorComponent } from "@app/components/error/error.component";
import { HomeComponent } from "@app/components/home/home.component";
import { SignInComponent } from "@app/components/sign-in/sign-in.component";
import { WorkspaceComponent } from "@app/components/workspace/workspace.component";
import { identityCanActivateFn } from "@app/guards/identity.guards";

export const routes: Routes = [
  {
    path: "error",
    component: ErrorComponent
  },
  {
    path: "sign-in",
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
        component: WorkspaceComponent
      }
    ]
  }
];
