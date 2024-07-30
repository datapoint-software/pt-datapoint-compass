using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Workspace.Facilities;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Workspace.Facilities
{
    [Route("/api/workspace/facilities")]
    public sealed class WorkspaceFacilityController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceFacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("update")]
        [WorkspaceFacility]
        public async Task<WorkspaceFacilityUpdateModel> GetUpdateAsync([FromQuery] Guid? facilityId, CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceFacilityUpdateQuery, WorkspaceFacilityUpdate>(
                new WorkspaceFacilityUpdateQuery(
                    facilityId),
                ct);

            return new WorkspaceFacilityUpdateModel(
                result.FacilityId,
                result.FacilityRowVersionId,
                result.Form is not null
                    ? new WorkspaceFacilityUpdateFormModel(
                        result.Form.Code,
                        result.Form.Name,
                        result.Form.Description)
                    : null);
        }

        [HttpGet("search")]
        [WorkspaceFacility]
        public async Task<WorkspaceFacilitySearchModel> SearchAsync([FromQuery] string? filter, [FromQuery] int? skip, [FromQuery] int? take, CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceFacilitySearchQuery, WorkspaceFacilitySearch>(
                new WorkspaceFacilitySearchQuery(
                    filter,
                    skip,
                    take),
                ct);

            return new WorkspaceFacilitySearchModel(
                result.Results.Select(r => new WorkspaceFacilitySearchResultModel(
                    r.Id,
                    r.Code,
                    r.Name,
                    r.Description)),
                result.TotalResultCount);
        }

        [HttpPost("update/submit")]
        [WorkspaceFacility]
        public async Task<WorkspaceFacilityUpdateSubmitResultModel> SubmitUpdateAsync([FromBody] WorkspaceFacilityUpdateSubmitModel model, CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<WorkspaceFacilityUpdateSubmitCommand, WorkspaceFacilityUpdateSubmitResult>(
                new WorkspaceFacilityUpdateSubmitCommand(
                    model.FacilityId,
                    model.FacilityRowVersionId,
                    new WorkspaceFacilityUpdateForm(
                        model.Form.Code,
                        model.Form.Name,
                        model.Form.Description)),
                ct);

            return new WorkspaceFacilityUpdateSubmitResultModel(
                result.FacilityId,
                result.FacilityRowVersionId);
        }
    }
}
