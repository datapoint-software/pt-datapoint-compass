import { Directive, ElementRef, HostBinding, HostListener, inject, OnInit } from "@angular/core";

@Directive({
  selector: "[data-bs-toggle='dropdown']",
  standalone: true
})
export class DataBsToggleDropdownDirective implements OnInit {

  private readonly _elementRef: ElementRef<HTMLElement> = inject(ElementRef);

  private _target!: HTMLElement;

  ngOnInit(): void {
    this._target = this._elementRef.nativeElement.parentElement!.querySelector(".dropdown-menu")!;
  }

  @HostBinding("ariaExpanded")
  private _ariaExpanded!: string | null;

  @HostBinding("class.show")
  private _show!: boolean;

  @HostListener("document:click", [ "$event" ])
  private _onDocumentClick(e: PointerEvent): void {
    this._ariaExpanded = "false";
    this._show = false;
    this._target.classList.remove("show");
  }

  @HostListener("click", [ "$event" ])
  private _onClick(e: PointerEvent): void {

    e.preventDefault();
    e.stopPropagation();

    this._show = !this._show;

    this._ariaExpanded = this._show
      ? "true"
      : "false";

    this._show
      ? this._target.classList.add("show")
      : this._target.classList.remove("show");
  }
}
