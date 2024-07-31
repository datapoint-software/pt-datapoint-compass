using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceSearchQueryHandler : IQueryHandler<WorkspaceServiceSearchQuery, WorkspaceServiceSearch>
    {
        private readonly CompassContext _context;

        public WorkspaceServiceSearchQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceServiceSearch> HandleQueryAsync(WorkspaceServiceSearchQuery query, CancellationToken ct)
        {
            var queryable = _context.Services.AsQueryable();

            if (!string.IsNullOrEmpty(query.Filter))
            {
                var patternExpression = ExpressionHelper.CreateLikePatternExpression(query.Filter);
                queryable = queryable.Where(e => EF.Functions.Like(e.Name, patternExpression));
            }

            var resultCount = await queryable.CountAsync(ct);

            if (resultCount == 0)
                return new WorkspaceServiceSearch([], 0);

            var skip = query.Skip ?? 0;
            var take = query.Take ?? 25;

            var results = await queryable
                .OrderBy(f => f.Name)
                    .ThenBy(f => f.Code)
                .Skip(skip)
                .Take(take)
                .ToListAsync(ct);

            return new WorkspaceServiceSearch(
                results.Select(f => new WorkspaceServiceSearchResult(
                    f.Id,
                    f.Code,
                    f.Name,
                    f.Description)),
                resultCount);
        }
    }
}
