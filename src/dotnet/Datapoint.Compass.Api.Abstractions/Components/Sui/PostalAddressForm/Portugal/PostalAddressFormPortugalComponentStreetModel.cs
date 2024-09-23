namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentStreetModel
    {
        public PostalAddressFormPortugalComponentStreetModel(string districtCode, string countyCode, string localityCode, string streetCode, string name)
        {
            DistrictCode = districtCode;
            CountyCode = countyCode;
            LocalityCode = localityCode;
            StreetCode = streetCode;
            Name = name;
        }

        public string DistrictCode { get; }

        public string CountyCode { get; }

        public string LocalityCode { get; }

        public string StreetCode { get; }

        public string Name { get; }
    }
}
