using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchResultModel
    {
        public PostalAddressFormPortugalComponentSearchResultModel(IEnumerable<PostalAddressFormPortugalComponentDistrictModel> districts, IEnumerable<PostalAddressFormPortugalComponentCountyModel> counties, IEnumerable<PostalAddressFormPortugalComponentLocalityModel> localities, IEnumerable<PostalAddressFormPortugalComponentStreetModel> streets)
        {
            Districts = districts;
            Counties = counties;
            Localities = localities;
            Streets = streets;
        }

        public IEnumerable<PostalAddressFormPortugalComponentDistrictModel> Districts { get; }

        public IEnumerable<PostalAddressFormPortugalComponentCountyModel> Counties { get; }

        public IEnumerable<PostalAddressFormPortugalComponentLocalityModel> Localities { get; }

        public IEnumerable<PostalAddressFormPortugalComponentStreetModel> Streets { get; }
    }
}
