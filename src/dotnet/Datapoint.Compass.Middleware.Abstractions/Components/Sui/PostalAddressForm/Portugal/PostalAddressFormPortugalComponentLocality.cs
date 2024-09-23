namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentLocality
    {
        public PostalAddressFormPortugalComponentLocality(string districtCode, string countyCode, string localityCode, string name)
        {
            DistrictCode = districtCode;
            CountyCode = countyCode;
            LocalityCode = localityCode;
            Name = name;
        }

        public string DistrictCode { get; }

        public string CountyCode { get; }

        public string LocalityCode { get; }

        public string Name { get; }
    }
}
