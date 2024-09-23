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
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Client, VaryByQueryKeys = ["countryCode", "districtCode", "name", "skip", "take", "cb"])]
        public async Task<IEnumerable<DistrictModel>> SearchAsync(
            [FromQuery] string? countryCode,
            [FromQuery] string? districtCode,
            [FromQuery] string? name,
            [FromQuery] int? skip,
            [FromQuery] int? take,
            CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<DistrictQuery, IEnumerable<District>>(
                new DistrictQuery(
                    countryCode,
                    districtCode,
                    name,
                    skip,
                    take),
                ct);

            return result.Select(d => new DistrictModel(
                d.CountryCode,
                d.DistrictCode,
                d.Name));
        }
    }
}
