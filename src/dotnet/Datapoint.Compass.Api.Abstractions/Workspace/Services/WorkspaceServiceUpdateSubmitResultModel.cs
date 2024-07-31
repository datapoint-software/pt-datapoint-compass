using System;

namespace Datapoint.Compass.Api.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitResultModel
    {
        public WorkspaceServiceUpdateSubmitResultModel(Guid serviceId, Guid serviceRowVersionId)
        {
            ServiceId = serviceId;
            ServiceRowVersionId = serviceRowVersionId;
        }

        public Guid ServiceId { get; }

        public Guid ServiceRowVersionId { get; }
    }
}
