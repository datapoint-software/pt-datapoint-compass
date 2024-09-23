namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentStreet
    {
        public PostalAddressFormPortugalComponentStreet(string districtCode, string countyCode, string localityCode, string streetCode, string name)
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
