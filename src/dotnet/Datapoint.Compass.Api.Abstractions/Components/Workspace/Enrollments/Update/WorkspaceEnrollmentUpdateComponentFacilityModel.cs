using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentFacilityModel
    {
        public WorkspaceEnrollmentUpdateComponentFacilityModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}