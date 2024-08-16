using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentQuery : Query<WorkspaceEnrollmentUpdateComponent>
    {
        public WorkspaceEnrollmentUpdateComponentQuery(Guid? enrollmentId)
        {
            EnrollmentId = enrollmentId;
        }

        public Guid? EnrollmentId { get; }
    }
}
