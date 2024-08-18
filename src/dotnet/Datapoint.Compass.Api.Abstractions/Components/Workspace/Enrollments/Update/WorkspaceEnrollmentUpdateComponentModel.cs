using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentModel
    {
        public WorkspaceEnrollmentUpdateComponentModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, string countryCode, string? districtCode, IEnumerable<WorkspaceEnrollmentUpdateComponentFacilityModel> facilities, IEnumerable<WorkspaceEnrollmentUpdateComponentServiceModel> services, string? number, WorkspaceEnrollmentUpdateComponentFormModel? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            CountryCode = countryCode;
            DistrictCode = districtCode;
            Facilities = facilities;
            Services = services;
            Number = number;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public string CountryCode { get; }

        public string? DistrictCode { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentFacilityModel> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentUpdateComponentServiceModel> Services { get; }

        public string? Number { get; }

        public WorkspaceEnrollmentUpdateComponentFormModel? Form { get; }
    }
}
