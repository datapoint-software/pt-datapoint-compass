namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentCounty
    {
        public PostalAddressFormPortugalComponentCounty(string districtCode, string countyCode, string name)
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
