namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentCountyModel
    {
        public PostalAddressFormPortugalComponentCountyModel(string districtCode, string countyCode, string name)
        {
            DistrictCode = districtCode;
            CountyCode = countyCode;
            Name = name;
        }

        public string DistrictCode { get; }

        public string CountyCode { get; }

        public string Name { get; }
    }
}
