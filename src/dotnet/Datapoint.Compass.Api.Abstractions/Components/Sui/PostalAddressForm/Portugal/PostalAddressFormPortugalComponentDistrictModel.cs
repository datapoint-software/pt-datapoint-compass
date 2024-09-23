namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentDistrictModel
    {
        public PostalAddressFormPortugalComponentDistrictModel(string districtCode, string name)
        {
            DistrictCode = districtCode;
            Name = name;
        }

        public string DistrictCode { get; }

        public string Name { get; }
    }
}
