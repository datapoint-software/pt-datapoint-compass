using Datapoint.Compass.Enumerations;
using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentModel
    {
        public WorkspaceEnrollmentUpdateComponentModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, string countryCode, string? districtCode, EnrollmentStatus status, IEnumerable<WorkspaceEnrollmentUpdateComponentFacilityModel> facilities, IEnumerable<WorkspaceEnrollmentUpdateComponentServiceModel> services, string? number, WorkspaceEnrollmentUpdateComponentFormModel? form)
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

        public IEnumerable<WorkspaceEnrollmentUpdateComponentFacilityModel> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentServiceModel> Services { get; }

        public string? Number { get; }

        public WorkspaceEnrollmentUpdateComponentFormModel? Form { get; }
    }
}
