using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Workspace.Home
{
    public sealed class WorkspaceHomeComponentQueryHandler : IQueryHandler<WorkspaceHomeComponentQuery, WorkspaceHomeComponent>
    {
        private readonly CompassContext _compass;

        public WorkspaceHomeComponentQueryHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<WorkspaceHomeComponent> HandleQueryAsync(WorkspaceHomeComponentQuery query, CancellationToken ct)
        {
            var enrollmentCount = await _compass.Enrollments.CountAsync(ct);

            return new WorkspaceHomeComponent(
                enrollmentCount);
        }
    }
}
