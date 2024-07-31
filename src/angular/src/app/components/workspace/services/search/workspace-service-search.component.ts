import { Component, inject, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { WorkspaceServiceSearchResultModel } from "@app/services/workspace/services/workspace-service.service.abstractions";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ RouterLink ],
  selector: "app-workspace-service-search",
  standalone: true,
  templateUrl: "workspace-service-search.component.html"
})
export class WorkspaceServiceSearchComponent implements OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _router = inject(Router);

  results!: WorkspaceServiceSearchResultModel[];
  totalResultCount!: number;

  service(id: string): void {
    this._router.navigate([ '/workspace/services', id ]);
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this.results = model.results;
        this.totalResultCount = model.totalResultCount;
      });
  }
}
