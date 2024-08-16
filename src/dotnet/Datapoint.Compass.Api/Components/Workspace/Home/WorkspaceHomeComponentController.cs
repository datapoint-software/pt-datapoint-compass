using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Components.Workspace.Home;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Components.Workspace.Home
{
    [Route("/api/components/workspace/home")]
    public sealed class WorkspaceHomeComponentController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceHomeComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Workspace]
        public async Task<WorkspaceHomeComponentModel> GetAsync(CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceHomeComponentQuery, WorkspaceHomeComponent>(
                new WorkspaceHomeComponentQuery(),
                ct);

            return new WorkspaceHomeComponentModel(
                result.EnrollmentCount);
        }
    }
}
