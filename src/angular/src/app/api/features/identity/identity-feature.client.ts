import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { IdentityFeatureModel, IdentityFeatureSignInModel } from "@app/api/features/identity/identity-feature.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class IdentityFeatureClient {

  private static readonly _baseAddress: string = "/api/features/identity";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  refresh(): Promise<IdentityFeatureModel> {
    return firstValueFrom(
      this._httpClient.post<IdentityFeatureModel>(
        `${IdentityFeatureClient._baseAddress}/refresh`,
        null
      )
    );
  }

  signIn(model: IdentityFeatureSignInModel): Promise<IdentityFeatureModel> {
    return firstValueFrom(
      this._httpClient.post<IdentityFeatureModel>(
        `${IdentityFeatureClient._baseAddress}/sign-in`,
        model
      )
    );
  }
}
