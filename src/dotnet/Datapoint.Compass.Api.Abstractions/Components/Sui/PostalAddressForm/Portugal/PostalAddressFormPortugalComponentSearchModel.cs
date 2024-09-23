namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchModel
    {
        public PostalAddressFormPortugalComponentSearchModel(string postalCode)
        {
            PostalCode = postalCode;
        }

        public string PostalCode { get; }
    }
}
