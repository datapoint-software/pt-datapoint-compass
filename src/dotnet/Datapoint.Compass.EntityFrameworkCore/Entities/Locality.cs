﻿namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Locality
    {
        public string CountryCode { get; set; } = default!;

        public string DistrictCode { get; set; } = default!;

        public string CountyCode { get; set; } = default!;

        public string LocalityCode { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
}
