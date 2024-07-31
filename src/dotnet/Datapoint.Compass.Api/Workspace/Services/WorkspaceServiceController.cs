using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Workspace.Services;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Workspace.Services
{
    [Route("/api/workspace/services")]
    public sealed class WorkspaceServiceController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("update")]
        [WorkspaceService]
        public async Task<WorkspaceServiceUpdateModel> GetUpdateAsync([FromQuery] Guid? serviceId, CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceServiceUpdateQuery, WorkspaceServiceUpdate>(
                new WorkspaceServiceUpdateQuery(
                    serviceId),
                ct);

            return new WorkspaceServiceUpdateModel(
                result.ServiceId,
                result.ServiceRowVersionId,
                result.Form is not null
                    ? new WorkspaceServiceUpdateFormModel(
                        result.Form.Code,
                        result.Form.Name,
                        result.Form.Description)
                    : null);
        }

        [HttpGet("search")]
        [WorkspaceService]
        public async Task<WorkspaceServiceSearchModel> SearchAsync([FromQuery] string? filter, [FromQuery] int? skip, [FromQuery] int? take, CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceServiceSearchQuery, WorkspaceServiceSearch>(
                new WorkspaceServiceSearchQuery(
                    filter,
                    skip,
                    take),
                ct);

            return new WorkspaceServiceSearchModel(
                result.Results.Select(r => new WorkspaceServiceSearchResultModel(
                    r.Id,
                    r.Code,
                    r.Name,
                    r.Description)),
                result.TotalResultCount);
        }

        [HttpPost("update/submit")]
        [WorkspaceService]
        public async Task<WorkspaceServiceUpdateSubmitResultModel> SubmitUpdateAsync([FromBody] WorkspaceServiceUpdateSubmitModel model, CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<WorkspaceServiceUpdateSubmitCommand, WorkspaceServiceUpdateSubmitResult>(
                new WorkspaceServiceUpdateSubmitCommand(
                    model.ServiceId,
                    model.ServiceRowVersionId,
                    new WorkspaceServiceUpdateForm(
                        model.Form.Code,
                        model.Form.Name,
                        model.Form.Description)),
                ct);

            return new WorkspaceServiceUpdateSubmitResultModel(
                result.ServiceId,
                result.ServiceRowVersionId);
        }
    }
}
