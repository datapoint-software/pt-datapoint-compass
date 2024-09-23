export interface PostalAddressFormPortugalComponentCountyModel {
  districtCode: string;
  countyCode: string;
  name: string;
}

export interface PostalAddressFormPortugalComponentDistrictModel {
  districtCode: string;
  name: string;
}

export interface PostalAddressFormPortugalComponentLocalityModel {
  districtCode: string;
  countyCode: string;
  localityCode: string;
  name: string;
}

export interface PostalAddressFormPortugalComponentSearchModel {
  postalCode: string;
}

export interface PostalAddressFormPortugalComponentSearchResultModel {
  districts: PostalAddressFormPortugalComponentDistrictModel[];
  counties: PostalAddressFormPortugalComponentCountyModel[];
  localities: PostalAddressFormPortugalComponentLocalityModel[];
  streets: PostalAddressFormPortugalComponentStreetModel[];
}

export interface PostalAddressFormPortugalComponentStreetModel {
  districtCode: string;
  countyCode: string;
  localityCode: string;
  streetCode: string;
  name: string;
}
