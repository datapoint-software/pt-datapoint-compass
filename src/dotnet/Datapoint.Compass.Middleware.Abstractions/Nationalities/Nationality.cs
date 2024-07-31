namespace Datapoint.Compass.Middleware.Nationalities
{
    public sealed class Nationality
    {
        public Nationality(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}