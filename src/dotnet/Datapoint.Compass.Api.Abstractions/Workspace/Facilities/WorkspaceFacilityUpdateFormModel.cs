namespace Datapoint.Compass.Api.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateFormModel
    {
        public WorkspaceFacilityUpdateFormModel(string code, string name, string? description)
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
