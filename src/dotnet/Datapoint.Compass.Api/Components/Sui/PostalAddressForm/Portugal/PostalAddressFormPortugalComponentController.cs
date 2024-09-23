using Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Components.Sui.PostalAddressForm.Portugal
{
    [Route("/api/components/sui/postal-address-form/portugal")]
    public sealed class PostalAddressFormPortugalComponentController : Controller
    {
        private readonly IMediator _mediator;

        public PostalAddressFormPortugalComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<PostalAddressFormPortugalComponentSearchResultModel> SearchAsync(
            [FromBody] PostalAddressFormPortugalComponentSearchModel model,
            CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<PostalAddressFormPortugalComponentSearchCommand, PostalAddressFormPortugalComponentSearchResult>(
                new PostalAddressFormPortugalComponentSearchCommand(
                    model.PostalCode),
                ct);

            return new PostalAddressFormPortugalComponentSearchResultModel(
                result.Districts.Select(d => new PostalAddressFormPortugalComponentDistrictModel(
                    d.DistrictCode,
                    d.Name)),
                result.Counties.Select(c => new PostalAddressFormPortugalComponentCountyModel(
                    c.DistrictCode,
                    c.CountyCode,
                    c.Name)),
                result.Localities.Select(l => new PostalAddressFormPortugalComponentLocalityModel(
                    l.DistrictCode,
                    l.CountyCode,
                    l.LocalityCode,
                    l.Name)),
                result.Streets.Select(s => new PostalAddressFormPortugalComponentStreetModel(
                    s.DistrictCode,
                    s.CountyCode,
                    s.LocalityCode,
                    s.StreetCode,
                    s.Name)));
        }
    }
}
