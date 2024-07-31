using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateQuery : Query<WorkspaceEnrollmentUpdate>
    {
        public WorkspaceEnrollmentUpdateQuery(Guid? enrollmentId)
        {
            EnrollmentId = enrollmentId;
        }

        public Guid? EnrollmentId { get; }
    }
}
