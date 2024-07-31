namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Parameter
    {
        public string Name { get; set; } = default!;

        public string JsonValue { get; set; } = default!;
    }
}
