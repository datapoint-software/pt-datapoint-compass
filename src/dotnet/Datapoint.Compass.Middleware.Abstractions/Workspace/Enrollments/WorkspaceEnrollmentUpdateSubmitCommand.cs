using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitCommand : Command<WorkspaceEnrollmentUpdateSubmitResult>
    {
        public WorkspaceEnrollmentUpdateSubmitCommand(Guid? enrollmentId, Guid? enrollmentRowVersionId, WorkspaceEnrollmentUpdateForm form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public WorkspaceEnrollmentUpdateForm Form { get; }
    }
}
