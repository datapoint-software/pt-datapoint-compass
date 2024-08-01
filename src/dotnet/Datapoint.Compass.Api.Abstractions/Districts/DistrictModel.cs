namespace Datapoint.Compass.Api.Districts
{
    public sealed class DistrictModel
    {
        public DistrictModel(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
