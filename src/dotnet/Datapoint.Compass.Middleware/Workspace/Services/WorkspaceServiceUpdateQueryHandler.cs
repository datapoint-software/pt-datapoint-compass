using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateQueryHandler : IQueryHandler<WorkspaceServiceUpdateQuery, WorkspaceServiceUpdate>
    {
        private readonly CompassContext _context;

        public WorkspaceServiceUpdateQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceServiceUpdate> HandleQueryAsync(WorkspaceServiceUpdateQuery query, CancellationToken ct)
        {
            if (!query.ServiceId.HasValue)
                return new WorkspaceServiceUpdate(null, null, null);

            var facility = await _context.Services
                .Where(f => f.Id == query.ServiceId)
                .FirstAsync(ct);

            return new WorkspaceServiceUpdate(
                facility.Id,
                facility.RowVersionId,
                new WorkspaceServiceUpdateForm(
                    facility.Code,
                    facility.Name,
                    facility.Description));
        }
    }
}
