import { DatePipe } from "@angular/common";
import { Component, inject, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, ResolveFn, RouterLink } from "@angular/router";
import { WorkspaceEnrollmentSearchComponentClient } from "@app/api/components/workspace/enrollments/search/workspace-enrollment-search-component.client";
import { WorkspaceEnrollmentSearchComponentFacilityModel, WorkspaceEnrollmentSearchComponentModel, WorkspaceEnrollmentSearchComponentSearchResultModel, WorkspaceEnrollmentSearchComponentServiceModel } from "@app/api/components/workspace/enrollments/search/workspace-enrollment-search-component.client.abstractions";
import { EnrollmentStatus } from "@app/app.enums";
import { SuiFormGroupComponent } from "@app/components/sui/form-group/sui-form-group.component";
import { WorkspaceEnrollmentSearchComponentForm } from "@app/components/workspace/enrollments/search/workspace-enrollment-search.component.abstractions";
import { LoadingOverlayFeature } from "@app/features/loading-overlay/loading-overlay.feature";
import { optionOf, optionsOf } from "@app/helpers/enum.helpers";
import { fromValueOf } from "@app/helpers/form.helpers";
import { EnrollmentStatusLabelPipe } from "@app/pipes/enrollment-status-label.pipe";
import { Subject, takeUntil } from "rxjs";

@Component({
  imports: [ DatePipe, EnrollmentStatusLabelPipe, ReactiveFormsModule, RouterLink, SuiFormGroupComponent ],
  selector: "app-workspace-enrollment-search",
  standalone: true,
  templateUrl: "workspace-enrollment-search.component.html"
})
export class WorkspaceEnrollmentSearchComponent implements OnDestroy, OnInit {

  static readonly model: ResolveFn<WorkspaceEnrollmentSearchComponentModel> = () =>
    inject(WorkspaceEnrollmentSearchComponentClient).get();

  private readonly _activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private readonly _destroy$: Subject<true> = new Subject();
  private readonly _fb: FormBuilder = inject(FormBuilder);
  private readonly _loadingOverlay: LoadingOverlayFeature = inject(LoadingOverlayFeature);
  private readonly _workspaceEnrollmentSearchComponentClient: WorkspaceEnrollmentSearchComponentClient = inject(WorkspaceEnrollmentSearchComponentClient);

  facilities!: Map<string, WorkspaceEnrollmentSearchComponentFacilityModel>;
  searchResult?: WorkspaceEnrollmentSearchComponentSearchResultModel;
  searchResultPage?: number;
  searchResultPageCount?: number;
  services!: Map<string, WorkspaceEnrollmentSearchComponentServiceModel>;
  statuses: EnrollmentStatus[] = optionsOf(EnrollmentStatus);

  form: WorkspaceEnrollmentSearchComponentForm = this._fb.group({
    filter: this._fb.control("", [ Validators.maxLength(128) ]),
    serviceId: this._fb.control("", [ ]),
    facilityId: this._fb.control("", [ ]),
    status: this._fb.control("", [])
  });

  ngOnDestroy(): void {
    this._destroy$.next(true);
    this._destroy$.complete();
  }

  ngOnInit(): void {
    this._activatedRoute.data
      .pipe(takeUntil(this._destroy$))
      .subscribe(({ model }) => {
        this.facilities = new Map(model.facilities.map((f: WorkspaceEnrollmentSearchComponentFacilityModel) => ([ f.id, f ])));
        this.services = new Map(model.services.map((s: WorkspaceEnrollmentSearchComponentServiceModel) => ([ s.id, s ])));
      });

    this.search();
  }

  search(): Promise<void> {
    return this._loadingOverlay.enqueueWhile(async () => {

      this.searchResult = await this._workspaceEnrollmentSearchComponentClient.search({
        ...fromValueOf({
          value: {
            ...this.form.value,
            status: optionOf(EnrollmentStatus, this.form.value.status)
          }
        }),
        skip: 0,
        take: 25
      });

      this.searchResultPage = 1;
      this.searchResultPageCount = Math.ceil(this.searchResult.totalMatchCount / 25);
    });
  }
}
