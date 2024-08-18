using Datapoint.Mediator;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQuery : Query<IEnumerable<District>>
    {
        public DistrictQuery(string? code, string? countryCode, string? name, int? skip, int? take)
        {
            Code = code;
            CountryCode = countryCode;
            Name = name;
            Skip = skip;
            Take = take;
        }

        public string? Code { get; }

        public string? CountryCode { get; }

        public string? Name { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
