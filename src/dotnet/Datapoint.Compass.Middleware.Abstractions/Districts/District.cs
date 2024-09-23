namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class District
    {
        public District(string countryCode, string districtCode, string name)
        {
            CountryCode = countryCode;
            DistrictCode = districtCode;
            Name = name;
        }

        public string CountryCode { get; }

        public string DistrictCode { get; }

        public string Name { get; }
    }
}
