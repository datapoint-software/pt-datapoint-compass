import { AnimationBuilder } from "@angular/animations";
import { Component, ElementRef, EventEmitter, inject, Input, NgZone, Output, ViewChild } from "@angular/core";
import { SuiModalComponentAction } from "@app/components/sui/modal/sui-modal.component.abstractions";
import { forCheck } from "@app/helpers/detection.helper";

@Component({
  selector: "app-sui-modal",
  standalone: true,
  templateUrl: "sui-modal.component.html"
})
export class SuiModalComponent {

  private readonly _ab = inject(AnimationBuilder);
  private readonly _ngZone = inject(NgZone);

  @Input() actions?: SuiModalComponentAction[];
  @Input() dismissible: boolean = true;
  @Input() title: string = $localize `:@@sui-modal-title:Alert`;

  @ViewChild("backdrop") backdrop?: ElementRef<HTMLDivElement>;
  @ViewChild("modal") modal?: ElementRef<HTMLDivElement>;

  visible: boolean = false;

  async close(): Promise<void> {

    this.backdrop?.nativeElement.classList.remove("show");
    this.modal?.nativeElement.classList.remove("show");

    await new Promise<void>((resolve) => {

      setTimeout(() => {

        this._ngZone.run(() => {
          this.visible = false;
        });

        resolve();

      }, 350);
    });
  }

  async open(): Promise<void> {

    this.visible = true;

    await forCheck(() => !!this.backdrop);
    await forCheck(() => !!this.modal);

    // We're doing this because there's a weird issue where
    // the fade-in animation is interrupted if the user clicks
    // way too fast on the dialog button.
    await new Promise<void>((resolve) => {
      setTimeout(() => {

        this._ngZone.runOutsideAngular(() => {
          this.backdrop!.nativeElement.classList.add("show");
          this.modal!.nativeElement.classList.add("show");
        });

        resolve();
      }, 50);
    });
  }

  protected async execute(action: SuiModalComponentAction): Promise<void> {
    await this.close();
    action.fn();
  }
}
