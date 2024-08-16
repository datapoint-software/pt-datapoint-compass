using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentServiceModel
    {
        public WorkspaceEnrollmentSearchComponentServiceModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}
