import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { CountryModel } from "@app/api/countries/country.client.abstractions";
import { APP_VERSION_ID } from "@app/app.constants";
import { firstValueFrom } from "rxjs";

@Injectable()
export class CountryClient {

  private static readonly _baseAddress: string = "/api/countries";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  search(params?: {
    code?: string;
    name?: string
  }): Promise<CountryModel[]> {
    return firstValueFrom(
      this._httpClient.get<CountryModel[]>(
        `${CountryClient._baseAddress}`,
        ({ params: { ...params, cb: APP_VERSION_ID } })
      )
    );
  }

}
