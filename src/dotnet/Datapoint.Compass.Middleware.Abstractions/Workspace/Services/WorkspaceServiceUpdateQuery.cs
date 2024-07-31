using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateQuery : Query<WorkspaceServiceUpdate>
    {
        public WorkspaceServiceUpdateQuery(Guid? serviceId)
        {
            ServiceId = serviceId;
        }

        public Guid? ServiceId { get; }
    }
}
