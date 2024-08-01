using Datapoint.Mediator;
using System.Collections;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQuery : Query<IEnumerable<District>>
    {
        public DistrictQuery(string countryCode)
        {
            CountryCode = countryCode;
        }

        public string CountryCode { get; }
    }
}
