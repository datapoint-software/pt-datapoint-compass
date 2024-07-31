using Datapoint.Compass.EntityFrameworkCore;
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
        private readonly CompassContext _context;

        public WorkspaceEnrollmentUpdateQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceEnrollmentUpdate> HandleQueryAsync(WorkspaceEnrollmentUpdateQuery query, CancellationToken ct)
        {
            var facilities = await _context.Facilities
                .OrderBy(f => f.Name)
                .ToListAsync(ct);

            if (query.EnrollmentId.HasValue is false)
            {
                return new WorkspaceEnrollmentUpdate(
                    null,
                    null,
                    facilities.Select(f => new WorkspaceEnrollmentFacility(
                        f.Id,
                        f.Name)),
                    null);
            }                

            throw new NotImplementedException();
        }
    }
}
