import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { NationalityModel } from "@app/services/nationalities/nationality.service.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class NationalityService {

  private readonly _baseAddress = "/api/nationalities";
  private readonly _httpClient = inject(HttpClient);

  getAll(params: {
    locale?: string
  }): Promise<NationalityModel[]> {
    return firstValueFrom(
      this._httpClient.get<NationalityModel[]>(
        `${this._baseAddress}`,
        ({ params })
      )
    );
  }

}
