using Datapoint.Compass.Middleware.Countries;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Countries
{
    [Route("/api/countries")]
    public sealed class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Client, VaryByQueryKeys = [ "code", "name", "skip", "take" ])]
        public async Task<IEnumerable<CountryModel>> SearchAsync(
            [FromQuery] string? code,
            [FromQuery] string? name,
            [FromQuery] int? skip,
            [FromQuery] int? take,
            CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<CountryQuery, IEnumerable<Country>>(
                new CountryQuery(
                    code,
                    name,
                    skip,
                    take),
                ct);

            return result.Select(c => new CountryModel(
                c.CountryCode,
                c.Name));
        }
    }
}
