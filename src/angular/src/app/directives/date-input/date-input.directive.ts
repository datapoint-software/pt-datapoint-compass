import { Directive, ElementRef, forwardRef, HostListener, inject, OnDestroy, OnInit } from "@angular/core";
import { ControlValueAccessor, FormControlDirective, NG_VALUE_ACCESSOR } from "@angular/forms";
import { Subject } from "rxjs";

@Directive({
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DateInputDirective),
      multi: true
    }
  ],
  selector: "input[type='date']",
  standalone: true,
})
export class DateInputDirective implements ControlValueAccessor, OnDestroy, OnInit {

  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _elementRef: ElementRef<HTMLInputElement> = inject(ElementRef);

  private _onChangeFn?: (value: string | null) => void;
  private _onTouchFn?: () => void;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
  }

  @HostListener("blur")
  onBlur(): void {
    this._onTouchFn?.();
  }

  @HostListener("change", [ "$event" ])
  onChange(e: InputEvent): void {
    this._onChangeFn?.(
      ((e.target as HTMLInputElement).valueAsDate)
        ? ((e.target as HTMLInputElement).valueAsDate)!.toISOString()
        : null
    );
  }

  registerOnChange(fn: (value: string | null) => void): void {
    this._onChangeFn = fn;
  }

  registerOnTouched(fn: () => void): void {
    this._onTouchFn = fn;
  }

  setDisabledState(state: boolean): void {
    this._elementRef.nativeElement.disabled = state;
  }

  writeValue(obj: any): void {
    this._elementRef.nativeElement.valueAsDate = obj
      ? new Date(obj)
      : null;
  }
}
