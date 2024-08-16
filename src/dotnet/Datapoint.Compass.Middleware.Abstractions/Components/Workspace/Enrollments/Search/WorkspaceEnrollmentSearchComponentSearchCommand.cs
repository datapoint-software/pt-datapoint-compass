using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchCommand : Command<WorkspaceEnrollmentSearchComponentSearchResult>
    {
        public WorkspaceEnrollmentSearchComponentSearchCommand(string? filter, Guid? serviceId, Guid? facilityId, EnrollmentStatus? status, int? skip, int? take)
        {
            Filter = filter;
            ServiceId = serviceId;
            FacilityId = facilityId;
            Status = status;
            Skip = skip;
            Take = take;
        }

        public string? Filter { get; }

        public Guid? ServiceId { get; }

        public Guid? FacilityId { get; }

        public EnrollmentStatus? Status { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
