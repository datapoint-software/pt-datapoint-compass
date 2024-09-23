namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class Country
    {
        public Country(string countryCode, string name)
        {
            CountryCode = countryCode;
            Name = name;
        }

        public string CountryCode { get; }

        public string Name { get; }
    }
}
