using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQueryHandler : IQueryHandler<DistrictQuery, IEnumerable<District>>
    {
        private readonly CompassContext _compass;

        public DistrictQueryHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<IEnumerable<District>> HandleQueryAsync(DistrictQuery query, CancellationToken ct)
        {
            var queryable = _compass.Districts
                .OrderBy(d => d.Name)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.Code))
                queryable = queryable.Where(d => d.Code == query.Code);

            if (!string.IsNullOrEmpty(query.CountryCode))
                queryable = queryable.Where(d => d.CountryCode == query.CountryCode);

            if (!string.IsNullOrEmpty(query.Name))
                queryable = queryable.Where(d => d.Name == query.Name);

            if (query.Skip.HasValue)
                queryable = queryable.Skip(query.Skip.Value);

            if (query.Take.HasValue)
                queryable = queryable.Take(query.Take.Value);

            var districts = await queryable.ToListAsync(ct);

            return districts.Select(d => new District(
                d.Code,
                d.CountryCode,
                d.Name));
        }
    }
}
