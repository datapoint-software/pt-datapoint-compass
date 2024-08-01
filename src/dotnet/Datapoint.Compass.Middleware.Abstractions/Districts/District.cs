namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class District
    {
        public District(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
