import { Component, inject, Input, OnDestroy, OnInit } from "@angular/core";
import { FormControl, FormGroupDirective, ValidationErrors, Validators } from "@angular/forms";
import { ERROR_MESSAGE_TRANSLATIONS, ERROR_MESSAGE_DEFAULT_TRANSLATION } from "@app/components/sui/form-group/sui-form-group.component.constants";
import { Subject, takeUntil } from "rxjs";

let LAST_ID = 1;

@Component({
  selector: "app-sui-form-group",
  standalone: true,
  templateUrl: "sui-form-group.component.html"
})
export class SuiFormGroupComponent implements OnDestroy, OnInit {

  private readonly _destroy$ = new Subject<true>();
  private readonly _formGroup = inject(FormGroupDirective);

  @Input() formControl!: FormControl<unknown | null>;
  @Input() id!: string;
  @Input() name!: string;

  errors!: ValidationErrors | null;
  messages!: string[];
  invalid!: boolean;
  required!: boolean;
  valid!: boolean;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    const id = ++LAST_ID;

    if (this.name)
      this.formControl = this._formGroup.control.get(this.name)! as FormControl<unknown | null>;

    else if (this.formControl)
      this.name ??= `sui-form-group-control-${id}`;

    this.id ??= `sui-form-group-control-${id}`;

    this.formControl.events
      .pipe(takeUntil(this._destroy$))
      .subscribe(() => {
        this._formControlChanges();
      });

    this._formControlChanges();
  }

  private _formControlChanges(): void {

    this.errors = this.formControl.errors;
    this.invalid = (this.formControl.dirty || this.formControl.touched) && this.formControl.invalid;
    this.required = this.formControl.hasValidator(Validators.required);
    this.valid = this.formControl.valid;

    this.messages = Object.keys(this.errors ?? {})
      .map((token) => ERROR_MESSAGE_TRANSLATIONS.get(token) ?? ERROR_MESSAGE_DEFAULT_TRANSLATION);
  }
}
