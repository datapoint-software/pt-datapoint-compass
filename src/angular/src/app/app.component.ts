import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterOutlet } from "@angular/router";
import { SuiLoadingOverlayComponent } from "@app/components/sui/loading-overlay/sui-loading-overlay.component";
import { LoadingOverlay } from "@app/features/loading-overlay/loading-overlay.feature";
import { filter, Subject, takeUntil } from "rxjs";

@Component({
  imports: [ RouterOutlet, SuiLoadingOverlayComponent ],
  selector: "app-root",
  standalone: true,
  templateUrl: "app.component.html"
})
export class AppComponent implements OnDestroy, OnInit {

  private readonly _destroy$ = new Subject<true>();
  private readonly _loadingOverlay = inject(LoadingOverlay);
  private readonly _router = inject(Router);

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {

    this._router.events
      .pipe(takeUntil(this._destroy$))
      .pipe(filter(e => e instanceof NavigationCancel || e instanceof NavigationEnd || e instanceof NavigationError))
      .subscribe(() => { this._loadingOverlay.dequeue("navigation"); });

    this._router.events
      .pipe(takeUntil(this._destroy$))
      .pipe(filter(e => e instanceof NavigationStart))
      .subscribe(() => { this._loadingOverlay.enqueue("navigation"); });
  }

}
