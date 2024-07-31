namespace Datapoint.Compass.Api.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateFormModel
    {
        public WorkspaceServiceUpdateFormModel(string code, string name, string? description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        public string Code { get; }

        public string Name { get; }

        public string? Description { get; }
    }
}
