using System;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitResult
    {
        public WorkspaceServiceUpdateSubmitResult(Guid serviceId, Guid serviceRowVersionId)
        {
            ServiceId = serviceId;
            ServiceRowVersionId = serviceRowVersionId;
        }

        public Guid ServiceId { get; }

        public Guid ServiceRowVersionId { get; }
    }
}
