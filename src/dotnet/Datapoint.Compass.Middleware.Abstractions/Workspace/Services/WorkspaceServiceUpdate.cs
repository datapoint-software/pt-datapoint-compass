using System;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdate
    {
        public WorkspaceServiceUpdate(Guid? serviceId, Guid? serviceRowVersionId, WorkspaceServiceUpdateForm? form)
        {
            ServiceId = serviceId;
            ServiceRowVersionId = serviceRowVersionId;
            Form = form;
        }

        public Guid? ServiceId { get; }

        public Guid? ServiceRowVersionId { get; }

        public WorkspaceServiceUpdateForm? Form { get; }
    }
}
