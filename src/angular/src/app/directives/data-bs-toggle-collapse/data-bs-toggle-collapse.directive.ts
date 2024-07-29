import { animate, AnimationBuilder, style } from "@angular/animations";
import { Directive, ElementRef, HostListener, inject, Input, OnDestroy, OnInit } from "@angular/core";

@Directive({
  selector: "[data-bs-toggle='collapse']",
  standalone: true
})
export class DataBsToggleCollapseDirective implements OnDestroy, OnInit {

  private readonly _animationBuilder = inject(AnimationBuilder);
  private readonly _elementRef = inject(ElementRef);

  private _onDocumentClickFn = (e: MouseEvent) => this._onDocumentClick(e);

  @Input() href?: string;
  @Input("data-bs-target") target?: string;
  @Input("data-bs-duration") duration: number = 250;

  ngOnDestroy(): void {
    document.removeEventListener("click", this._onDocumentClickFn);
  }

  ngOnInit(): void {
    document.addEventListener("click", this._onDocumentClickFn);
  }

  private _collapse(source: HTMLElement, target: HTMLElement): void {
    source.setAttribute("aria-expanded", "false");
    source.classList.add("collapsed");

    target.classList.remove("collapse");
    target.classList.add("collapsing");

    this._animationBuilder.build([
      style({ height: target.scrollHeight }),
      animate(this.duration, style({ height: 0 }))
    ])
      .create(target)
      .play();

    setTimeout(() => {
      target.classList.remove("collapsing");
      target.classList.add("collapse");
      target.classList.remove("show");
    }, this.duration);
  }

  private _expand(source: HTMLElement, target: HTMLElement): void {
    source.setAttribute("aria-expanded", "true");
    source.classList.remove("collapsed");

    target.classList.remove("collapse");
    target.classList.add("collapsing");

    this._animationBuilder.build([
      style({ height: 0 }),
      animate(this.duration, style({ height: target.scrollHeight })),
      style({ height: "unset" })
    ])
      .create(target)
      .play();

    setTimeout(() => {
      target.classList.remove("collapsing");
      target.classList.add("collapse");
      target.classList.add("show");
    }, this.duration);
  }

  @HostListener("click", [ "$event" ])
  private _onClick(e: PointerEvent): void {

    e.preventDefault();
    e.stopPropagation();

    const source = this._elementRef.nativeElement;

    if (!(source instanceof HTMLElement))
      return;

    const target = document.querySelector(`${this.target || this.href}.collapse`);

    if (!(target instanceof HTMLElement))
      return;

    source.classList.contains("collapsed")
      ? this._expand(source, target)
      : this._collapse(source, target);
  }

  private _onDocumentClick(e: MouseEvent): void {

    if (window.innerWidth > 1199)
      return;

    const source = this._elementRef.nativeElement;

    if (!(source instanceof HTMLElement))
      return;

    const target = document.querySelector(`${this.target || this.href}.collapse`);

    if (!(target instanceof HTMLElement))
      return;

    source.classList.contains("collapsed") ||
      this._collapse(source, target);
  }

}
