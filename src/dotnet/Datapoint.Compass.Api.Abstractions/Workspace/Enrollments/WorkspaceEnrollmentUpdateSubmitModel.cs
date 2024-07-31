using System;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitModel
    {
        public WorkspaceEnrollmentUpdateSubmitModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, WorkspaceEnrollmentUpdateFormModel form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public WorkspaceEnrollmentUpdateFormModel Form { get; }
    }
}
