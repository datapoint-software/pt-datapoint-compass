using Datapoint.Mediator;

namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchCommand : Command<PostalAddressFormPortugalComponentSearchResult>
    {
        public PostalAddressFormPortugalComponentSearchCommand(string areaCode)
        {
            PostalCode = areaCode;
        }

        public string PostalCode { get; }
    }
}
