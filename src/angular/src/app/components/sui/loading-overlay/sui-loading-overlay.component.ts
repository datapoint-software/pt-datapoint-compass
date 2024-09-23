import { Component, inject } from "@angular/core";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";

@Component({
  selector: "app-sui-loading-overlay",
  standalone: true,
  templateUrl: "sui-loading-overlay.component.html"
})
export class SuiLoadingOverlayComponent {

  private readonly _loadingOverlayFeature: LoadingOverlayFeature = inject(LoadingOverlayFeature);

  items = this._loadingOverlayFeature.items;

}
