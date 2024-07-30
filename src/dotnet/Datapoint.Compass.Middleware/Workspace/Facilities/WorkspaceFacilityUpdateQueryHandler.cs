using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateQueryHandler : IQueryHandler<WorkspaceFacilityUpdateQuery, WorkspaceFacilityUpdate>
    {
        private readonly CompassContext _context;

        public WorkspaceFacilityUpdateQueryHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceFacilityUpdate> HandleQueryAsync(WorkspaceFacilityUpdateQuery query, CancellationToken ct)
        {
            if (!query.FacilityId.HasValue)
                return new WorkspaceFacilityUpdate(null, null, null);

            var facility = await _context.Facilities
                .Where(f => f.Id == query.FacilityId)
                .FirstAsync(ct);

            return new WorkspaceFacilityUpdate(
                facility.Id,
                facility.RowVersionId,
                new WorkspaceFacilityUpdateForm(
                    facility.Code,
                    facility.Name,
                    facility.Description));
        }
    }
}
