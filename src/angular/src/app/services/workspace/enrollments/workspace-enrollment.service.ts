import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceEnrollmentUpdateModel } from "@app/services/workspace/enrollments/workspace-enrollment.service.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceEnrollmentService {

  private readonly _baseAddress = "/api/workspace/enrollments";
  private readonly _httpClient = inject(HttpClient);

  getUpdate(params: {
    enrollmentId?: string
  }): Promise<WorkspaceEnrollmentUpdateModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceEnrollmentUpdateModel>(
        `${this._baseAddress}/update`,
        ({ params })
      )
    );
  }

}
