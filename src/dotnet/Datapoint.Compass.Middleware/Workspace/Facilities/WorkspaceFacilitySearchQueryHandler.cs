using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilitySearchQueryHandler : IQueryHandler<WorkspaceFacilitySearchQuery, WorkspaceFacilitySearch>
    {
        private readonly CompassContext _context;

        public WorkspaceFacilitySearchQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceFacilitySearch> HandleQueryAsync(WorkspaceFacilitySearchQuery query, CancellationToken ct)
        {
            var queryable = _context.Facilities.AsQueryable();

            if (!string.IsNullOrEmpty(query.Filter))
            {
                var patternExpression = ExpressionHelper.CreateLikePatternExpression(query.Filter);
                queryable = queryable.Where(e => EF.Functions.Like(e.Name, patternExpression));
            }

            var resultCount = await queryable.CountAsync(ct);

            if (resultCount == 0)
                return new WorkspaceFacilitySearch([], 0);

            var skip = query.Skip ?? 0;
            var take = query.Take ?? 25;

            var results = await queryable
                .OrderBy(f => f.Name)
                    .ThenBy(f => f.Code)
                .Skip(skip)
                .Take(take)
                .ToListAsync(ct);

            return new WorkspaceFacilitySearch(
                results.Select(f => new WorkspaceFacilitySearchResult(
                    f.Id,
                    f.Code,
                    f.Name,
                    f.Description)),
                resultCount);
        }
    }
}
