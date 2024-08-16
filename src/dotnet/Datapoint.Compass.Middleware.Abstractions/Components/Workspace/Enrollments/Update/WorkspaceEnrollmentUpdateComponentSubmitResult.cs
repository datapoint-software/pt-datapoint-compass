using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitResult
    {
        public WorkspaceEnrollmentUpdateComponentSubmitResult(Guid enrollmentId, Guid enrollmentRowVersionId, string number)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Number = number;
        }

        public Guid EnrollmentId { get; }

        public Guid EnrollmentRowVersionId { get; }

        public string Number { get; }
    }
}