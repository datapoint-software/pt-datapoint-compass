import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute, ResolveFn } from "@angular/router";
import { WorkspaceHomeComponentClient } from "@app/api/components/workspace/home/workspace-home-component.client";
import { WorkspaceHomeComponentModel } from "@app/api/components/workspace/home/workspace-home-component.client.abstractions";
import { Subject, takeUntil } from "rxjs";

@Component({
  selector: "app-workspace-home",
  standalone: true,
  templateUrl: "workspace-home.component.html"
})
export class WorkspaceHomeComponent implements OnDestroy, OnInit {

  static readonly model: ResolveFn<WorkspaceHomeComponentModel> = () =>
    inject(WorkspaceHomeComponentClient).get();

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();

  enrollmentCount?: number;

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this.enrollmentCount = model.enrollmentCount;
      });
  }

}
