namespace Datapoint.Compass.Api.Countries
{
    public sealed class CountryModel
    {
        public CountryModel(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
