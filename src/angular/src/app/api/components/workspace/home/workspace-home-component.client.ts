import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { WorkspaceHomeComponentModel } from "@app/api/components/workspace/home/workspace-home-component.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class WorkspaceHomeComponentClient {

  private static readonly _baseAddress: string = "/api/components/workspace/home";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  get(): Promise<WorkspaceHomeComponentModel> {
    return firstValueFrom(
      this._httpClient.get<WorkspaceHomeComponentModel>(
        `${WorkspaceHomeComponentClient._baseAddress}`
      )
    );
  }

}
