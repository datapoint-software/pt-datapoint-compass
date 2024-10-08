﻿using Datapoint.Compass.Enumerations;
using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchModel
    {
        public WorkspaceEnrollmentSearchComponentSearchModel(string? filter, Guid? serviceId, Guid? facilityId, EnrollmentStatus? status, int? skip, int? take)
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
