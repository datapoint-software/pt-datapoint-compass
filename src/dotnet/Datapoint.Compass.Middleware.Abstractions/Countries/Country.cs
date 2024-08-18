namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class Country
    {
        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
