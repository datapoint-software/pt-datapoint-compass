namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Sequence
    {
        public string Name { get; set; } = default!;

        public int LastNumber { get; set; } = default!;
    }
}
