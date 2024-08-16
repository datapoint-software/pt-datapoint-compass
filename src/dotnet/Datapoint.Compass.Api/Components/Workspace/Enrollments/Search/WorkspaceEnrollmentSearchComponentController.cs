using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    [Route("/api/components/workspace/enrollments/search")]
    public sealed class WorkspaceEnrollmentSearchComponentController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceEnrollmentSearchComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [WorkspaceEnrollment]
        public async Task<WorkspaceEnrollmentSearchComponentModel> GetAsync(CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceEnrollmentSearchComponentQuery, WorkspaceEnrollmentSearchComponent>(
                new WorkspaceEnrollmentSearchComponentQuery(),
                ct);

            return new WorkspaceEnrollmentSearchComponentModel(
                result.Services.Select(s => new WorkspaceEnrollmentSearchComponentServiceModel(
                    s.Id,
                    s.Name)),
                result.Facilities.Select(f => new WorkspaceEnrollmentSearchComponentFacilityModel(
                    f.Id,
                    f.Name)));
        }

        [HttpPost]
        [WorkspaceEnrollment]
        public async Task<WorkspaceEnrollmentSearchComponentSearchResultModel> SearchAsync(
            [FromBody] WorkspaceEnrollmentSearchComponentSearchModel model,
            CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<WorkspaceEnrollmentSearchComponentSearchCommand, WorkspaceEnrollmentSearchComponentSearchResult>(
                new WorkspaceEnrollmentSearchComponentSearchCommand(
                    model.Filter,
                    model.ServiceId,
                    model.FacilityId,
                    model.Status,
                    model.Skip,
                    model.Take),
                ct);

            return new WorkspaceEnrollmentSearchComponentSearchResultModel(
                result.TotalMatchCount,
                result.Matches.Select(m => new WorkspaceEnrollmentSearchComponentSearchResultMatchModel(
                    m.Id,
                    m.ServiceId,
                    m.FacilityId,
                    m.Number,
                    m.Status,
                    m.Creation,
                    m.Start)));
        }
    }
}
