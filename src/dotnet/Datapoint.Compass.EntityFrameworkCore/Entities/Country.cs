﻿namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Country
    {
        public string Code { get; set; } = default!;

        public string CodeA3 { get; set; } = default!;

        public string CodeN3 { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Nationality { get; set; } = default!;
    }
}
