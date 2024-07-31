using System;
using System.Collections;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdate
    {
        public WorkspaceEnrollmentUpdate(Guid? enrollmentId, Guid? enrollmentRowVersionId, IEnumerable<WorkspaceEnrollmentFacility> facilities, WorkspaceEnrollmentUpdateForm? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Facilities = facilities;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public IEnumerable<WorkspaceEnrollmentFacility> Facilities { get; }

        public WorkspaceEnrollmentUpdateForm? Form { get; }
    }
}
