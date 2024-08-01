using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQueryHandler : IQueryHandler<DistrictQuery, IEnumerable<District>>
    {
        private readonly IMemoryCache _memoryCache;

        private readonly CompassContext _context;

        public DistrictQueryHandler(IMemoryCache memoryCache, CompassContext context)
        {
            _memoryCache = memoryCache;
            _context = context;
        }

        public Task<IEnumerable<District>> HandleQueryAsync(DistrictQuery query, CancellationToken ct) =>
            
            _memoryCache.GetOrCreateAsync($"districts/{query.CountryCode}", async (_) =>
            {
                var districts = await _context.Districts
                    .AsNoTracking()
                    .Where(d => d.CountryCode == query.CountryCode)
                    .OrderBy(d => d.Name)
                    .Select(d => new { d.Code, d.Name })
                    .ToListAsync(ct);

                return districts.Select(d => new District(
                    d.Code,
                    d.Name));
            })!;
    }
}
