using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Workspace.Enrollments;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    [Route("/api/workspace/enrollments")]
    public sealed class WorkspaceEnrollmentController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceEnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("update")]
        [WorkspaceEnrollment]
        public async Task<WorkspaceEnrollmentUpdateModel> GetUpdateAsync(
            [FromQuery] Guid? enrollmentId,
            CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceEnrollmentUpdateQuery, WorkspaceEnrollmentUpdate>(
                new WorkspaceEnrollmentUpdateQuery(
                    enrollmentId),
                ct);

            return new WorkspaceEnrollmentUpdateModel(
                result.EnrollmentId,
                result.EnrollmentRowVersionId,
                result.Facilities.Select(f => new WorkspaceEnrollmentFacilityModel(
                    f.Id,
                    f.Name)),
                result.Services.Select(f => new WorkspaceEnrollmentServiceModel(
                    f.Id,
                    f.Name)),
                result.Form is null
                    ? new WorkspaceEnrollmentUpdateFormModel()
                    : null);
        }
    }
}
