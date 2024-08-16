using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentFacility
    {
        public WorkspaceEnrollmentSearchComponentFacility(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}