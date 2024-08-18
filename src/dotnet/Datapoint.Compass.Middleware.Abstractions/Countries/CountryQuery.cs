using Datapoint.Mediator;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class CountryQuery : Query<IEnumerable<Country>>
    {
        public CountryQuery(string? code, string? name, int? skip, int? take)
        {
            Code = code;
            Name = name;
            Skip = skip;
            Take = take;
        }

        public string? Code { get; }

        public string? Name { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
