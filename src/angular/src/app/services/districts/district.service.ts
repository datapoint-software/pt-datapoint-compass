import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { DistrictModel } from "@app/services/districts/district.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class DistrictService {

  private readonly _baseAddress = "/api/districts";
  private readonly _httpClient = inject(HttpClient);

  getAll(params: {
    countryCode: string,
    locale?: string
  }): Promise<DistrictModel[]> {
    return firstValueFrom(
      this._httpClient.get<DistrictModel[]>(
        `${this._baseAddress}`,
        ({ params })
      )
    );
  }

}
