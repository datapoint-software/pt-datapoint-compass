import { Component, inject, OnInit } from "@angular/core";
import { RouterLink, RouterOutlet } from "@angular/router";
import { Permission } from "@app/app.enums";
import { DataBsToggleCollapseDirective } from "@app/directives/data-bs-toggle-collapse/data-bs-toggle-collapse.directive";
import { Identity } from "@app/features/identity/identity.feature";
import { AvatarLabelPipe } from "@app/pipes/avatar-label/avatar-label.pipe";

@Component({
  imports: [ AvatarLabelPipe, DataBsToggleCollapseDirective, RouterLink, RouterOutlet ],
  selector: "app-workspace",
  standalone: true,
  templateUrl: "workspace.component.html"
})
export class WorkspaceComponent implements OnInit {

  private readonly _identity = inject(Identity);

  enrollments!: boolean;
  facilities!: boolean;
  management!: boolean;
  name!: string;
  services!: boolean;

  ngOnInit(): void {
    this.enrollments = this._identity.permissions.has(Permission.WorkspaceEnrollments);
    this.facilities = this._identity.permissions.has(Permission.WorkspaceFacilities);
    this.name = this._identity.name!;
    this.services = this._identity.permissions.has(Permission.WorkspaceServices);

    this.management = this.facilities || this.services;
  }
}
