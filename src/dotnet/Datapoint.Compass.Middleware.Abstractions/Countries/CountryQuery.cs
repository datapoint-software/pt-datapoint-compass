using Datapoint.Mediator;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class CountryQuery : Query<IEnumerable<Country>>
    {
        public CountryQuery(string? code, string? name, int? skip, int? take)
        {
            CountryCode = code;
            Name = name;
            Skip = skip;
            Take = take;
        }

        public string? CountryCode { get; }

        public string? Name { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
