using System;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitResult
    {
        public WorkspaceEnrollmentUpdateSubmitResult(Guid enrollmentId, Guid enrollmentRowVersionId, string number)
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