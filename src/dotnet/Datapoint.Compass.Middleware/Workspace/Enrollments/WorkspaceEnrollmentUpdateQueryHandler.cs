using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateQueryHandler : IQueryHandler<WorkspaceEnrollmentUpdateQuery, WorkspaceEnrollmentUpdate>
    {
        private readonly static string[] ParameterNames = 
        [
            "Country"
        ];

        private readonly CompassContext _context;

        public WorkspaceEnrollmentUpdateQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceEnrollmentUpdate> HandleQueryAsync(WorkspaceEnrollmentUpdateQuery query, CancellationToken ct)
        {
            var parameters = await _context.Parameters
                .AsNoTracking()
                .Where(p => ParameterNames.Contains(p.Name))
                .ToDictionaryAsync(p => p.Name, ct);

            var facilities = await _context.Facilities
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .ToListAsync(ct);

            var services = await _context.Services
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .ToListAsync(ct);

            var enrollment = query.EnrollmentId.HasValue
                ? await _context.Enrollments
                    .Where(e => e.Id == query.EnrollmentId)
                    .FirstAsync(ct)
                : null;

            return new WorkspaceEnrollmentUpdate(
                enrollment?.Id,
                enrollment?.RowVersionId,
                parameters.GetValueOf<string>("Country"),
                enrollment?.Number,
                facilities.Select(f => new WorkspaceEnrollmentFacility(
                    f.Id,
                    f.Name)),
                services.Select(f => new WorkspaceEnrollmentService(
                    f.Id,
                    f.Name)),
                enrollment is not null
                    ? new WorkspaceEnrollmentUpdateForm(
                        enrollment.FacilityId,
                        enrollment.ServiceId,
                        enrollment.Start)
                    : null);
        }
    }
}
