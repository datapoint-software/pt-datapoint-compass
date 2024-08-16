using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponent
    {
        public WorkspaceEnrollmentUpdateComponent(Guid? enrollmentId, Guid? enrollmentRowVersionId, string countryCode, IEnumerable<WorkspaceEnrollmentUpdateComponentCountry> countries, IEnumerable<WorkspaceEnrollmentUpdateComponentFacility> facilities, IEnumerable<WorkspaceEnrollmentUpdateComponentService> services, string? number, WorkspaceEnrollmentUpdateComponentForm? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            CountryCode = countryCode;
            Countries = countries;
            Facilities = facilities;
            Services = services;
            Number = number;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public string CountryCode { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentCountry> Countries { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentFacility> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentService> Services { get; }

        public string? Number { get; }

        public WorkspaceEnrollmentUpdateComponentForm? Form { get; }
    }
}
