using Datapoint.Compass.Enumerations;
using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponent
    {
        public WorkspaceEnrollmentUpdateComponent(Guid? enrollmentId, Guid? enrollmentRowVersionId, string countryCode, string? districtCode, EnrollmentStatus status, IEnumerable<WorkspaceEnrollmentUpdateComponentFacility> facilities, IEnumerable<WorkspaceEnrollmentUpdateComponentService> services, string? number, WorkspaceEnrollmentUpdateComponentForm? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            CountryCode = countryCode;
            DistrictCode = districtCode;
            Status = status;
            Facilities = facilities;
            Services = services;
            Number = number;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public string CountryCode { get; }

        public string? DistrictCode { get; }

        public EnrollmentStatus Status { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentFacility> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentService> Services { get; }

        public string? Number { get; }

        public WorkspaceEnrollmentUpdateComponentForm? Form { get; }
    }
}
