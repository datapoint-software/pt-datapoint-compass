using System;

namespace Datapoint.Compass.Api.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitModel
    {
        public WorkspaceServiceUpdateSubmitModel(Guid? serviceId, Guid? serviceRowVersionId, WorkspaceServiceUpdateFormModel form)
        {
            ServiceId = serviceId;
            ServiceRowVersionId = serviceRowVersionId;
            Form = form;
        }

        public Guid? ServiceId { get; }

        public Guid? ServiceRowVersionId { get; }

        public WorkspaceServiceUpdateFormModel Form { get; }
    }
}
