using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitCommand : Command<WorkspaceServiceUpdateSubmitResult>
    {
        public WorkspaceServiceUpdateSubmitCommand(Guid? serviceId, Guid? serviceRowVersionId, WorkspaceServiceUpdateForm form)
        {
            ServiceId = serviceId;
            ServiceRowVersionId = serviceRowVersionId;
            Form = form;
        }

        public Guid? ServiceId { get; }

        public Guid? ServiceRowVersionId { get; }

        public WorkspaceServiceUpdateForm Form { get; }
    }
}
