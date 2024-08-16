import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceEnrollmentUpdateComponentModel, WorkspaceEnrollmentUpdateComponentSubmitModel, WorkspaceEnrollmentUpdateComponentSubmitResultModel } from "@app/api/components/workspace/enrollments/update/workspace-enrollment-update-component.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceEnrollmentUpdateComponentClient {

  private static readonly _baseAddress: string = "/api/components/workspace/enrollments/update";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  get(params: {
    enrollmentId?: string
  }): Promise<WorkspaceEnrollmentUpdateComponentModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceEnrollmentUpdateComponentModel>(
        `${WorkspaceEnrollmentUpdateComponentClient._baseAddress}`,
        ({ params })
      )
    );
  }

  submit(model: WorkspaceEnrollmentUpdateComponentSubmitModel): Promise<WorkspaceEnrollmentUpdateComponentSubmitResultModel> {
    return firstValueFrom(
      this._httpClient.post<WorkspaceEnrollmentUpdateComponentSubmitResultModel>(
        `${WorkspaceEnrollmentUpdateComponentClient._baseAddress}/submit`,
        model
      )
    );
  }

}
