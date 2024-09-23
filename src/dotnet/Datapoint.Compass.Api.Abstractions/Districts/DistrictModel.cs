namespace Datapoint.Compass.Api.Districts
{
    public sealed class DistrictModel
    {
        public DistrictModel(string countryCode, string districtCode, string name)
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
