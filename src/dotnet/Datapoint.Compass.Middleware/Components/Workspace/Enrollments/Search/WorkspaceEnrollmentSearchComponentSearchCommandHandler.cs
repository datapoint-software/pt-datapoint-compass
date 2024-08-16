using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchCommandHandler : ICommandHandler<WorkspaceEnrollmentSearchComponentSearchCommand, WorkspaceEnrollmentSearchComponentSearchResult>
    {
        private readonly CompassContext _compass;

        public WorkspaceEnrollmentSearchComponentSearchCommandHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<WorkspaceEnrollmentSearchComponentSearchResult> HandleCommandAsync(WorkspaceEnrollmentSearchComponentSearchCommand command, CancellationToken ct)
        {
            var queryable = _compass.Enrollments.AsQueryable();

            if (!string.IsNullOrEmpty(command.Filter))
            {
                var filterExpression = "%" + string.Join('%', command.Filter.Split(' ', StringSplitOptions.RemoveEmptyEntries)) + "%";

                queryable = queryable.Where(e =>
                    EF.Functions.Like(e.Number, filterExpression));
            }

            if (command.ServiceId.HasValue)
                queryable = queryable.Where(e => e.ServiceId == command.ServiceId);

            if (command.FacilityId.HasValue)
                queryable = queryable.Where(e => e.FacilityId == command.FacilityId);

            if (command.Status.HasValue)
                queryable = queryable.Where(e => e.Status == command.Status);

            var totalMatchCount = await queryable.CountAsync(ct);

            if (totalMatchCount == 0)
                return new WorkspaceEnrollmentSearchComponentSearchResult(0, []);

            var skip = command.Skip ?? 0;
            var take = command.Take ?? 0;

            var matches = await queryable
                .OrderBy(e => e.Number)
                .Skip(skip)
                .Take(take)
                .ToListAsync(ct);

            return new WorkspaceEnrollmentSearchComponentSearchResult(
                totalMatchCount,
                matches.Select(m => new WorkspaceEnrollmentSearchComponentSearchResultMatch(
                    m.Id,
                    m.ServiceId,
                    m.FacilityId,
                    m.Number,
                    m.Status,
                    m.Creation,
                    m.Start)));
        }
    }
}
