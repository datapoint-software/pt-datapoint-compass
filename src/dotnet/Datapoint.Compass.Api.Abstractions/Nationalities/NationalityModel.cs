namespace Datapoint.Compass.Api.Nationalities
{
    public sealed class NationalityModel
    {
        public NationalityModel(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
