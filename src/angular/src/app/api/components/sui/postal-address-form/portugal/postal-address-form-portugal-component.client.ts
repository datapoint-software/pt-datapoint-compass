import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { PostalAddressFormPortugalComponentSearchModel, PostalAddressFormPortugalComponentSearchResultModel } from "@app/api/components/sui/postal-address-form/portugal/postal-address-form-portugal-component.client.abstractions";
import { firstValueFrom } from "rxjs";

@Injectable()
export class SuiPostalAddressFormPortugalComponentClient {

  private static readonly _baseAddress: string = "/api/components/sui/postal-address-form/portugal";

  private readonly _httpClient: HttpClient = inject(HttpClient);

  search(model: PostalAddressFormPortugalComponentSearchModel): Promise<PostalAddressFormPortugalComponentSearchResultModel> {
    return firstValueFrom(
      this._httpClient.post<PostalAddressFormPortugalComponentSearchResultModel>(
        `${SuiPostalAddressFormPortugalComponentClient._baseAddress}/search`,
        model
      )
    );
  }

}
