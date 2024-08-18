namespace Datapoint.Compass.Api.Districts
{
    public sealed class DistrictModel
    {
        public DistrictModel(string code, string countryCode, string name)
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
