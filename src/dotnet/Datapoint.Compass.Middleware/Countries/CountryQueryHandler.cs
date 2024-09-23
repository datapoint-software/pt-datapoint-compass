using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class CountryQueryHandler : IQueryHandler<CountryQuery, IEnumerable<Country>>
    {
        private readonly CompassContext _compass;

        public CountryQueryHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<IEnumerable<Country>> HandleQueryAsync(CountryQuery query, CancellationToken ct)
        {
            var queryable = _compass.Countries
                .OrderBy(c => c.Name)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.CountryCode))
                queryable = queryable.Where(c => c.CountryCode == query.CountryCode);

            if (!string.IsNullOrEmpty(query.Name))
                queryable = queryable.Where(c => c.Name == query.Name);

            if (query.Skip.HasValue)
                queryable = queryable.Skip(query.Skip.Value);

            if (query.Take.HasValue)
                queryable = queryable.Take(query.Take.Value);

            var countries = await queryable.ToListAsync(ct);

            return countries.Select(c => new Country(
                c.CountryCode,
                c.Name));
        }
    }
}
