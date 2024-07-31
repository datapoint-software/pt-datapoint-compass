import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceServiceUpdateModel, WorkspaceServiceSearchModel, WorkspaceServiceUpdateSubmitModel, WorkspaceServiceUpdateSubmitResultModel } from "@app/services/workspace/services/workspace-service.service.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceServiceService {

  private readonly _baseAddress = "/api/workspace/services";
  private readonly _httpClient = inject(HttpClient);

  getUpdate(params: {
    serviceId?: string
  }): Promise<WorkspaceServiceUpdateModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceServiceUpdateModel>(
        `${this._baseAddress}/update`,
        ({ params })
      )
    );
  }

  getSearch(params: {
    filter?: string;
    skip?: number | string;
    take?: number | string;
  }): Promise<WorkspaceServiceSearchModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceServiceSearchModel>(
        `${this._baseAddress}/search`,
        { params }
      )
    );
  }

  submitUpdate(model: WorkspaceServiceUpdateSubmitModel): Promise<WorkspaceServiceUpdateSubmitResultModel> {
    return firstValueFrom(
      this._httpClient.post<WorkspaceServiceUpdateSubmitResultModel>(
        `${this._baseAddress}/update/submit`,
        model
      )
    );
  }
}
