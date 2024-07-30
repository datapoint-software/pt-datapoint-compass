namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateForm
    {
        public WorkspaceFacilityUpdateForm(string code, string name, string? description)
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
