import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceEnrollmentSearchComponentModel, WorkspaceEnrollmentSearchComponentSearchModel, WorkspaceEnrollmentSearchComponentSearchResultModel } from "@app/api/components/workspace/enrollments/search/workspace-enrollment-search-component.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceEnrollmentSearchComponentClient {

  private static readonly _baseAddress: string = "/api/components/workspace/enrollments/search";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  get(): Promise<WorkspaceEnrollmentSearchComponentModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceEnrollmentSearchComponentModel>(
        `${WorkspaceEnrollmentSearchComponentClient._baseAddress}`
      )
    );
  }

  search(model: WorkspaceEnrollmentSearchComponentSearchModel): Promise<WorkspaceEnrollmentSearchComponentSearchResultModel> {
    return firstValueFrom(
      this._httpClient.post<WorkspaceEnrollmentSearchComponentSearchResultModel>(
        `${WorkspaceEnrollmentSearchComponentClient._baseAddress}`,
        model
      )
    );
  }

}
