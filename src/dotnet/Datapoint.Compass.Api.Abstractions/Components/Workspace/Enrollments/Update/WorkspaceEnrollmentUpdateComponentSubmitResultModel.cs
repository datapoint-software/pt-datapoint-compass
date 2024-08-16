using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitResultModel
    {
        public WorkspaceEnrollmentUpdateComponentSubmitResultModel(Guid enrollmentId, Guid enrollmentRowVersionId, string number)
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
