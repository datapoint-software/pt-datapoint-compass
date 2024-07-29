import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { Subject, takeUntil } from "rxjs";

const STATUS_CODE_DESCRIPTIONS = new Map([
  [ "403", $localize `:@@error-message-forbidden:Sorry, you do not have sufficient permissions to access the resource at this location.` ],
  [ "404", $localize `:@@error-message-not-found:The document you are looking does not exist or may have been moved to a different location.`]
]);

const STATUS_CODE_TITLES = new Map([
  [ "403", $localize `:@@error-title-forbidden:Forbidden` ],
  [ "404", $localize `:@@error-title-not-found:Document not found` ]
]);

@Component({
  imports: [ RouterLink ],
  selector: "app-error",
  standalone: true,
  templateUrl: "error.component.html"
})
export class ErrorComponent implements OnDestroy, OnInit {

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();

  title: string = $localize `:@@error-title:Something went wrong!`;
  description: string = $localize `:@@error-description:We have encountered an unexpected error while attempting to process your last request.`;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.queryParamMap
      .pipe(takeUntil(this._destroy$))
      .subscribe((qs) => {

        const status = qs.get("status");

        if (status) {

          if (STATUS_CODE_DESCRIPTIONS.has(status))
            this.description = STATUS_CODE_DESCRIPTIONS.get(status)!;

          if (STATUS_CODE_TITLES.has(status))
            this.title = STATUS_CODE_TITLES.get(status)!;
        }
      });
  }
}
