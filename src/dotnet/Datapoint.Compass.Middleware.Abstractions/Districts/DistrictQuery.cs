using Datapoint.Mediator;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQuery : Query<IEnumerable<District>>
    {
        public DistrictQuery(string? countryCode, string? districtCode, string? name, int? skip, int? take)
        {
            CountryCode = countryCode;
            DistrictCode = districtCode;
            Name = name;
            Skip = skip;
            Take = take;
        }

        public string? CountryCode { get; }

        public string? DistrictCode { get; }

        public string? Name { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
