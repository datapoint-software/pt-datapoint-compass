import { Component, inject } from "@angular/core";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";

@Component({
  selector: "app-sui-loading-overlay",
  standalone: true,
  templateUrl: "sui-loading-overlay.component.html"
})
export class SuiLoadingOverlayComponent {

  private readonly _loadingOverlay: LoadingOverlay = inject(LoadingOverlay);

  readonly items = this._loadingOverlay.items;

}
