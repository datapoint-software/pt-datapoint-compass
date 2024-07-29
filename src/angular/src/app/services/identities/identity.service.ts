import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { IdentityModel, IdentitySignInModel } from "@app/services/identities/identity.service.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class IdentityService {

  private readonly _baseAddress = "/api/identities";
  private readonly _httpClient: HttpClient = inject(HttpClient);

  signIn(model: IdentitySignInModel): Promise<IdentityModel> {
    return firstValueFrom(
      this._httpClient.post<IdentityModel>(
        `${this._baseAddress}/sign-in`,
        model
      )
    );
  }

  refresh(): Promise<IdentityModel> {
    return firstValueFrom(
      this._httpClient.post<IdentityModel>(
        `${this._baseAddress}/refresh`,
        null
      )
    );
  }
}
