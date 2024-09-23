namespace Datapoint.Compass.Api.Countries
{
    public sealed class CountryModel
    {
        public CountryModel(string countryCode, string name)
        {
            CountryCode = countryCode;
            Name = name;
        }

        public string CountryCode { get; }

        public string Name { get; }
    }
}
