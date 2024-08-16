import { Component, inject, OnInit } from "@angular/core";
import { RouterLink, RouterOutlet } from "@angular/router";
import { Permission } from "@app/app.enums";
import { DataBsToggleCollapseDirective } from "@app/directives/data-bs-toggle-collapse/data-bs-toggle-collapse.directive";
import { IdentityFeature } from "@app/features/identity/identity.feature";
import { AvatarLabelPipe } from "@app/pipes/avatar-label/avatar-label.pipe";

@Component({
  imports: [ AvatarLabelPipe, DataBsToggleCollapseDirective, RouterLink, RouterOutlet ],
  selector: "app-workspace",
  standalone: true,
  templateUrl: "workspace.component.html"
})
export class WorkspaceComponent implements OnInit {

  private readonly _identityFeature: IdentityFeature = inject(IdentityFeature);

  enrollments!: boolean;
  name!: string;

  ngOnInit(): void {
    this.enrollments = this._identityFeature.permissions.has(Permission.WorkspaceEnrollment);
    this.name = this._identityFeature.name!;
  }
}
