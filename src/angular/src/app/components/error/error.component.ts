import { Component, inject } from "@angular/core";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { STATUS_CODE_DESCRIPTIONS, STATUS_CODE_TITLES } from "@app/components/error/error.component.constants";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ RouterLink ],
  selector: "app-error",
  standalone: true,
  templateUrl: "error.component.html"
})
export class ErrorComponent {

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();

  description: string = $localize `:@@error-description:We have encountered an unexpected error while attempting to process your last request.`;
  goBackHomeButtonEnabled!: boolean;
  title: string = $localize `:@@error-title:Something went wrong!`;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.queryParamMap
      .pipe(takeUntil(this._destroy$))
      .subscribe((queryString) => {

        const status = queryString.get("status");

        if (status) {

          if (STATUS_CODE_DESCRIPTIONS.has(status))
            this.description = STATUS_CODE_DESCRIPTIONS.get(status)!;

          if (STATUS_CODE_TITLES.has(status))
            this.title = STATUS_CODE_TITLES.get(status)!;
        }

        this.goBackHomeButtonEnabled = !(
          status && ([ "503" ]).includes(status)
        );
      });
  }

}
