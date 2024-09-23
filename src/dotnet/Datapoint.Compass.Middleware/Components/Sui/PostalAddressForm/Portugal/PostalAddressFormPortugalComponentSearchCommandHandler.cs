using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchCommandHandler : ICommandHandler<PostalAddressFormPortugalComponentSearchCommand, PostalAddressFormPortugalComponentSearchResult>
    {
        private const string PortugalCountryCode = "PT";

        private readonly CompassContext _compass;

        public PostalAddressFormPortugalComponentSearchCommandHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<PostalAddressFormPortugalComponentSearchResult> HandleCommandAsync(PostalAddressFormPortugalComponentSearchCommand command, CancellationToken ct)
        {
            var streets = await _compass.Streets
                .Where(s => s.PostalCode == command.PostalCode)
                .ToListAsync(ct);

            var districtCodes = streets.Select(s => s.DistrictCode).Distinct();
            var countyCodes = streets.Select(s => s.CountyCode).Distinct();
            var localityCodes = streets.Select(s => s.LocalityCode).Distinct();

            var districts = await _compass.Districts
                .AsNoTracking()
                .Where(d => d.CountryCode == PortugalCountryCode)
                .Where(d => districtCodes.Contains(d.DistrictCode))
                .ToListAsync(ct);

            var counties = await _compass.Counties
                .AsNoTracking()
                .Where(c => c.CountryCode == PortugalCountryCode)
                .Where(c => districtCodes.Contains(c.DistrictCode))
                .Where(c => countyCodes.Contains(c.CountyCode))
                .ToListAsync(ct);

            var localities = await _compass.Localities
                .AsNoTracking()
                .Where(l => l.CountryCode == PortugalCountryCode)
                .Where(l => districtCodes.Contains(l.DistrictCode))
                .Where(l => countyCodes.Contains(l.CountyCode))
                .Where(l => localityCodes.Contains(l.LocalityCode))
                .ToListAsync(ct);

            return new PostalAddressFormPortugalComponentSearchResult(
                districts.Select(d => new PostalAddressFormPortugalComponentDistrict(
                    d.DistrictCode,
                    d.Name)),
                counties.Select(c => new PostalAddressFormPortugalComponentCounty(
                    c.DistrictCode,
                    c.CountyCode,
                    c.Name)),
                localities.Select(l => new PostalAddressFormPortugalComponentLocality(
                    l.DistrictCode,
                    l.CountyCode,
                    l.LocalityCode,
                    l.Name)),
                streets.Select(pa => new PostalAddressFormPortugalComponentStreet(
                    pa.DistrictCode,
                    pa.CountyCode,
                    pa.LocalityCode,
                    pa.StreetCode,
                    pa.Name)));
        }
    }
}
