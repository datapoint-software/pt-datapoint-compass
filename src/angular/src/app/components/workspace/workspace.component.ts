import { Component, inject, OnInit } from "@angular/core";
import { RouterLink, RouterOutlet } from "@angular/router";
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

  name!: string;

  public ngOnInit(): void {
    this.name = this._identity.name!;
  }

}
