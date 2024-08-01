namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class District
    {
        public string CountryCode { get; set; } = default!;

        public string Code { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
}
