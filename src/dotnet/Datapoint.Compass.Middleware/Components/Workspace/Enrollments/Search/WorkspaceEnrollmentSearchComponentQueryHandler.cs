using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentQueryHandler : IQueryHandler<WorkspaceEnrollmentSearchComponentQuery, WorkspaceEnrollmentSearchComponent>
    {
        private readonly CompassContext _compass;

        public WorkspaceEnrollmentSearchComponentQueryHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<WorkspaceEnrollmentSearchComponent> HandleQueryAsync(WorkspaceEnrollmentSearchComponentQuery query, CancellationToken ct)
        {
            var services = await _compass.Services
                .OrderBy(s => s.Name)
                .Select(s => new { s.Id, s.Name })
                .ToListAsync(ct);

            var facilities = await _compass.Facilities
                .OrderBy(f => f.Name)
                .Select(f => new { f.Id, f.Name })
                .ToListAsync(ct);

            return new WorkspaceEnrollmentSearchComponent(
                services.Select(s => new WorkspaceEnrollmentSearchComponentService(
                    s.Id,
                    s.Name)),
                facilities.Select(f => new WorkspaceEnrollmentSearchComponentFacility(
                    f.Id,
                    f.Name)));
        }
    }
}
