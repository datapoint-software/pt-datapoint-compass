using System;
using System.Collections;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateModel
    {
        public WorkspaceEnrollmentUpdateModel(Guid? enrollmentId, Guid? enrollmentRowVersionId, IEnumerable<WorkspaceEnrollmentFacilityModel> facilities, WorkspaceEnrollmentUpdateFormModel? form)
        {
            EnrollmentId = enrollmentId;
            EnrollmentRowVersionId = enrollmentRowVersionId;
            Facilities = facilities;
            Form = form;
        }

        public Guid? EnrollmentId { get; }

        public Guid? EnrollmentRowVersionId { get; }

        public IEnumerable<WorkspaceEnrollmentFacilityModel> Facilities { get; }

        public WorkspaceEnrollmentUpdateFormModel? Form { get; }
    }
}
