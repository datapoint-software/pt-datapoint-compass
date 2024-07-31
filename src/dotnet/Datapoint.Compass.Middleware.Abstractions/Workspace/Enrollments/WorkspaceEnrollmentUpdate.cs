using System;
using System.Collections;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdate
    {
        public WorkspaceEnrollmentUpdate(Guid? enrollmentId, Guid? enrollmentRowVersionId, string country, string? number, IEnumerable<WorkspaceEnrollmentFacility> facilities, IEnumerable<WorkspaceEnrollmentService> services, WorkspaceEnrollmentUpdateForm? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Country = country;
            Number = number;
            Facilities = facilities;
            Services = services;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public string Country { get; }

        public string? Number { get; }

        public IEnumerable<WorkspaceEnrollmentFacility> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentService> Services { get; }

        public WorkspaceEnrollmentUpdateForm? Form { get; }
    }
}
