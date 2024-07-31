using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Nationalities
{
    public sealed class NationalityQuery : Query<IEnumerable<Nationality>>
    {
        public NationalityQuery(Locale? locale)
        {
            Locale = locale;
        }

        public Locale? Locale { get; }
    }
}
