import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { SuiLoadingOverlayComponent } from "@app/components/sui/loading-overlay/sui-loading-overlay.component";

@Component({
  imports: [ RouterOutlet, SuiLoadingOverlayComponent ],
  selector: "app-root",
  standalone: true,
  templateUrl: "app.component.html"
})
export class AppComponent {

}
