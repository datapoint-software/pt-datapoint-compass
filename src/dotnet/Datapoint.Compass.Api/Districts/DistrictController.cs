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
        [ResponseCache(Duration = 84600, VaryByQueryKeys = [ "countryCode", "locale", "version" ])]
        public async Task<IEnumerable<DistrictModel>> GetAllByCountryCodeAsync([FromQuery] string countryCode, CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<DistrictQuery, IEnumerable<District>>(
                new DistrictQuery(countryCode),
                ct);

            return result.Select(d => new DistrictModel(
                d.Code,
                d.Name));
        }
    }
}
