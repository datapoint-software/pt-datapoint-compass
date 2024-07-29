import { Directive, ElementRef, inject, OnDestroy, OnInit } from "@angular/core";

@Directive({
  selector: "[data-toggle-password]",
  standalone: true
})
export class DataTogglePasswordDirective implements OnDestroy, OnInit {

  private readonly _elementRef: ElementRef<HTMLElement> = inject(ElementRef);

  private readonly _clickEventListener = (e: Event) => {

    this._targetElement ??= this._findTargetElement();

    const hidden = this._targetElement.type === "password";

    this._targetElement.type = hidden
      ? "text"
      : "password";

    const { classList } = this._elementRef.nativeElement;

    hidden
      ? classList.add("pw-hidden")
      : classList.remove("pw-hidden");
  };

  private _targetElement?: HTMLInputElement;

  ngOnDestroy(): void {
    this._elementRef.nativeElement.removeEventListener("click", this._clickEventListener);
  }

  ngOnInit(): void {
    this._elementRef.nativeElement.addEventListener("click", this._clickEventListener);
  }

  private _findTargetElement(): HTMLInputElement {

    let { parentElement } = this._elementRef.nativeElement;

    while (parentElement) {

      const targetElement = parentElement.querySelector<HTMLInputElement>("input[data-toggle-password-input]");

      if (targetElement)
        return targetElement;

      parentElement = parentElement.parentElement;
    }

    throw new Error("Input element was not found for password toggle.");
  }
}
