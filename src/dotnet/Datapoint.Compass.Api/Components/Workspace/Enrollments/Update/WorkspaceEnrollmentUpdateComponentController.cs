using Datapoint.Compass.Api.Attributes;
using Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    [Route("/api/components/workspace/enrollments/update")]
    public sealed class WorkspaceEnrollmentUpdateComponentController : Controller
    {
        private readonly IMediator _mediator;

        public WorkspaceEnrollmentUpdateComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [WorkspaceEnrollment]
        public async Task<WorkspaceEnrollmentUpdateComponentModel> GetAsync(
            [FromQuery] Guid? enrollmentId,
            [FromQuery] string? languageCode,
            CancellationToken ct)
        {
            var result = await _mediator.HandleQueryAsync<WorkspaceEnrollmentUpdateComponentQuery, WorkspaceEnrollmentUpdateComponent>(
                new WorkspaceEnrollmentUpdateComponentQuery(
                    enrollmentId,
                    languageCode),
                ct);

            return new WorkspaceEnrollmentUpdateComponentModel(
                result.EnrollmentId,
                result.EnrollmentRowVersionId,
                result.CountryCode,
                result.DistrictCode,
                result.Status,
                result.Facilities.Select(f => new WorkspaceEnrollmentUpdateComponentFacilityModel(
                    f.Id,
                    f.Name)),
                result.Services.Select(s => new WorkspaceEnrollmentUpdateComponentServiceModel(
                    s.Id,
                    s.Name)),
                result.Number,
                result.Form is not null
                    ? new WorkspaceEnrollmentUpdateComponentFormModel(
                        result.Form.ServiceId,
                        result.Form.FacilityId,
                        result.Form.FacilityIds,
                        result.Form.Start,
                        result.Form.Comments)
                    : null);
        }

        [HttpPost("submit")]
        [WorkspaceEnrollment]
        public async Task<WorkspaceEnrollmentUpdateComponentSubmitResultModel> SubmitAsync(
            [FromBody] WorkspaceEnrollmentUpdateComponentSubmitModel model,
            CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<WorkspaceEnrollmentUpdateComponentSubmitCommand, WorkspaceEnrollmentUpdateComponentSubmitResult>(
                new WorkspaceEnrollmentUpdateComponentSubmitCommand(
                    model.EnrollmentId,
                    model.EnrollmentRowVersionId,
                    new WorkspaceEnrollmentUpdateComponentForm(
                        model.Form.ServiceId,
                        model.Form.FacilityId,
                        model.Form.FacilityIds,
                        model.Form.Start,
                        model.Form.Comments)),
                ct);

            return new WorkspaceEnrollmentUpdateComponentSubmitResultModel(
                result.EnrollmentId,
                result.EnrollmentRowVersionId,
                result.Number);
        }
    }
}

