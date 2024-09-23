using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchResult
    {
        public PostalAddressFormPortugalComponentSearchResult(IEnumerable<PostalAddressFormPortugalComponentDistrict> districts, IEnumerable<PostalAddressFormPortugalComponentCounty> counties, IEnumerable<PostalAddressFormPortugalComponentLocality> localities, IEnumerable<PostalAddressFormPortugalComponentStreet> streets)
        {
            Districts = districts;
            Counties = counties;
            Localities = localities;
            Streets = streets;
        }

        public IEnumerable<PostalAddressFormPortugalComponentDistrict> Districts { get; }

        public IEnumerable<PostalAddressFormPortugalComponentCounty> Counties { get; }

        public IEnumerable<PostalAddressFormPortugalComponentLocality> Localities { get; }

        public IEnumerable<PostalAddressFormPortugalComponentStreet> Streets { get; }
    }
}
