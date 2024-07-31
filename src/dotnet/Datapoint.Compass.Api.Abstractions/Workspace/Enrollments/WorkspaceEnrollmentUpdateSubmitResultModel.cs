using System;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitResultModel
    {
        public WorkspaceEnrollmentUpdateSubmitResultModel(Guid enrollmentId, Guid enrollmentRowVersionId, string number)
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
