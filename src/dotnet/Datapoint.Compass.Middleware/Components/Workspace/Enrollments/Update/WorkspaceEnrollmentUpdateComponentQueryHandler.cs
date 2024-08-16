using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentQueryHandler : IQueryHandler<WorkspaceEnrollmentUpdateComponentQuery, WorkspaceEnrollmentUpdateComponent>
    {
        private readonly CompassContext _compass;

        public WorkspaceEnrollmentUpdateComponentQueryHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<WorkspaceEnrollmentUpdateComponent> HandleQueryAsync(WorkspaceEnrollmentUpdateComponentQuery query, CancellationToken ct)
        {
            var facilities = await _compass.Facilities
                .AsNoTracking()
                .Select(f => new { f.Id, f.Name })
                .OrderBy(f => f.Name)
                .ToListAsync(ct);

            var services = await _compass.Services
                .AsNoTracking()
                .Select(s => new { s.Id, s.Name })
                .OrderBy(s => s.Name)
                .ToListAsync(ct);

            var enrollment = query.EnrollmentId.HasValue
                ? await _compass.Enrollments
                    .Where(e => e.Id == query.EnrollmentId)
                    .FirstAsync(ct)
                : null;

            return new WorkspaceEnrollmentUpdateComponent(
                enrollment?.Id,
                enrollment?.RowVersionId,
                facilities.Select(f => new WorkspaceEnrollmentUpdateComponentFacility(
                    f.Id,
                    f.Name)),
                services.Select(s => new WorkspaceEnrollmentUpdateComponentService(
                    s.Id,
                    s.Name)),
                enrollment?.Number,
                enrollment is not null
                    ? new WorkspaceEnrollmentUpdateComponentForm(
                        enrollment.ServiceId,
                        enrollment.FacilityId,
                        enrollment.Start,
                        enrollment.Comments)
                    : null);
        }
    }
}
