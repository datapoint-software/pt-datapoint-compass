import { Component, inject, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { WorkspaceFacilitySearchResultModel } from "@app/services/workspace/facilities/workspace-facility.service.abstractions";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ RouterLink ],
  selector: "app-workspace-facility-search",
  standalone: true,
  templateUrl: "workspace-facility-search.component.html"
})
export class WorkspaceFacilitySearchComponent implements OnInit {

  private readonly _activatedRoute = inject(ActivatedRoute);
  private readonly _destroy$ = new Subject<true>();
  private readonly _router = inject(Router);

  results!: WorkspaceFacilitySearchResultModel[];
  totalResultCount!: number;

  facility(id: string): void {
    this._router.navigate([ '/workspace/facilities', id ]);
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
