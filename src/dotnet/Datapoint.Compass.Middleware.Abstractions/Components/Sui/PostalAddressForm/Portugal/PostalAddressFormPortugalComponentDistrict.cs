namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentDistrict
    {
        public PostalAddressFormPortugalComponentDistrict(string districtCode, string name)
        {
            DistrictCode = districtCode;
            Name = name;
        }

        public string DistrictCode { get; }

        public string Name { get; }
    }
}
