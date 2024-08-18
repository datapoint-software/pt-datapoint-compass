import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { DistrictModel } from "@app/api/districts/district.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class DistrictClient {

  private static readonly _baseAddress: string = "/api/districts";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  search(params?: {
    code?: string;
    countryCode?: string;
    name?: string
  }): Promise<DistrictModel[]> {
    return firstValueFrom(
      this._httpClient.get<DistrictModel[]>(
        `${DistrictClient._baseAddress}`,
        ({ params })
      )
    );
  }

}
