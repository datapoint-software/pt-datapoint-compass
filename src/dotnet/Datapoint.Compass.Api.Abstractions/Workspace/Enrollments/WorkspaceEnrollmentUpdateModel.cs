using System;
using System.Collections;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateModel
    {
        public WorkspaceEnrollmentUpdateModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, string country, string? district, string? number, IEnumerable<WorkspaceEnrollmentFacilityModel> facilities, IEnumerable<WorkspaceEnrollmentServiceModel> services, WorkspaceEnrollmentUpdateFormModel? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Country = country;
            District = district;
            Number = number;
            Facilities = facilities;
            Services = services;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public string Country { get; }

        public string? District { get; }

        public string? Number { get; }

        public IEnumerable<WorkspaceEnrollmentFacilityModel> Facilities { get; }

        public IEnumerable<WorkspaceEnrollmentServiceModel> Services { get; }

        public WorkspaceEnrollmentUpdateFormModel? Form { get; }
    }
}
