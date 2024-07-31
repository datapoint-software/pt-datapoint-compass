using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Nationalities;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Nationalities
{
    [Route("/api/nationalities")]
    public sealed class NationalityController : Controller
    {
        private readonly IMediator _mediator;

        public NationalityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 86400, VaryByQueryKeys = [ "locale", "version" ])]
        [HttpGet]
        public async Task<IEnumerable<NationalityModel>> GetAllAsync([FromQuery] string? locale, CancellationToken ct)
        { 
            var result = await _mediator.HandleQueryAsync<NationalityQuery, IEnumerable<Nationality>>(
                new NationalityQuery(
                    string.IsNullOrEmpty(locale)
                        ? null
                        : locale switch
                            {
                                "en" => Locale.English,
                                "pt" => Locale.Portuguese,
                                _ => null
                            }),
                ct);

            return result.Select(n => new NationalityModel(
                n.Code,
                n.Name));
        }
    }
}
