using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitCommand : Command<WorkspaceEnrollmentUpdateComponentSubmitResult>
    {
        public WorkspaceEnrollmentUpdateComponentSubmitCommand(Guid? enrollmentId, Guid? enrollmentRowVersionId, WorkspaceEnrollmentUpdateComponentForm form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public WorkspaceEnrollmentUpdateComponentForm Form { get; }
    }
}
