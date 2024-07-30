import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceFacilityUpdateModel, WorkspaceFacilitySearchModel, WorkspaceFacilityUpdateSubmitModel, WorkspaceFacilityUpdateSubmitResultModel } from "@app/services/workspace/facilities/workspace-facility.service.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceFacilityService {

  private readonly _baseAddress = "/api/workspace/facilities";
  private readonly _httpClient = inject(HttpClient);

  getUpdate(params: {
    facilityId?: string
  }): Promise<WorkspaceFacilityUpdateModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceFacilityUpdateModel>(
        `${this._baseAddress}/update`,
        ({ params })
      )
    );
  }

  getSearch(params: {
    filter?: string;
    skip?: number | string;
    take?: number | string;
  }): Promise<WorkspaceFacilitySearchModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceFacilitySearchModel>(
        `${this._baseAddress}/search`,
        { params }
      )
    );
  }

  submitUpdate(model: WorkspaceFacilityUpdateSubmitModel): Promise<WorkspaceFacilityUpdateSubmitResultModel> {
    return firstValueFrom(
      this._httpClient.post<WorkspaceFacilityUpdateSubmitResultModel>(
        `${this._baseAddress}/update/submit`,
        model
      )
    );
  }
}
