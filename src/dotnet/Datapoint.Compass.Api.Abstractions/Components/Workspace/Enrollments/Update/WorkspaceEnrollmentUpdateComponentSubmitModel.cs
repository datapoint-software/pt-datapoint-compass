using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitModel
    {
        public WorkspaceEnrollmentUpdateComponentSubmitModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, WorkspaceEnrollmentUpdateComponentFormModel form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public WorkspaceEnrollmentUpdateComponentFormModel Form { get; }
    }
}
