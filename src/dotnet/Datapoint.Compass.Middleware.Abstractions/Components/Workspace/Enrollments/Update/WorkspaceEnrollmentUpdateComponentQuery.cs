using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentQuery : Query<WorkspaceEnrollmentUpdateComponent>
    {
        public WorkspaceEnrollmentUpdateComponentQuery(Guid? enrollmentId, string? languageCode)
        {
            EnrollmentId = enrollmentId;
            LanguageCode = languageCode;
        }

        public Guid? EnrollmentId { get; }

        public string? LanguageCode { get; }
    }
}
