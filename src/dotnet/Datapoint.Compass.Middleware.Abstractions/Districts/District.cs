namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class District
    {
        public District(string code, string countryCode, string name)
        {
            Code = code;
            CountryCode = countryCode;
            Name = name;
        }

        public string Code { get; }

        public string CountryCode { get; }

        public string Name { get; }
    }
}
