using Datapoint.Compass.Middleware.Districts;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Districts
{
    [Route("/api/districts")]
    public sealed class DistrictController : Controller
    {
        private readonly IMediator _mediator;

        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Client, VaryByQueryKeys = ["code", "countryCode", "name", "skip", "take"])]
        public async Task<IEnumerable<DistrictModel>> SearchAsync(
            [FromQuery] string? code,
            [FromQuery] string? countryCode,
            [FromQuery] string? name,
            [FromQuery] int? skip,
            [FromQuery] int? take,
            CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<DistrictQuery, IEnumerable<District>>(
                new DistrictQuery(
                    code,
                    countryCode,
                    name,
                    skip,
                    take),
                ct);

            return result.Select(d => new DistrictModel(
                d.Code,
                d.CountryCode,
                d.Name));
        }
    }
}
