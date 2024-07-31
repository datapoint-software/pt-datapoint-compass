using System;

namespace Datapoint.Compass.Api.Workspace.Services
{
    public sealed class WorkspaceServiceSearchResultModel
    {
        public WorkspaceServiceSearchResultModel(Guid id, string code, string name, string? description)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }

        public string Code { get; }

        public string Name { get; }

        public string? Description { get; }
    }
}