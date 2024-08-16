using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.EntityFrameworkCore.Entities;
using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitCommandHandler : ICommandHandler<WorkspaceEnrollmentUpdateComponentSubmitCommand, WorkspaceEnrollmentUpdateComponentSubmitResult>
    {
        private readonly CompassContext _compass;

        public WorkspaceEnrollmentUpdateComponentSubmitCommandHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<WorkspaceEnrollmentUpdateComponentSubmitResult> HandleCommandAsync(WorkspaceEnrollmentUpdateComponentSubmitCommand command, CancellationToken ct)
        {
            var enrollment = await GetOrCreateEnrollmentAsync(
                command,
                ct);

            var facility = command.Form.FacilityId.HasValue
                ? await _compass.Facilities
                    .Where(f => f.Id == command.Form.FacilityId)
                    .FirstAsync(ct)
                : null;

            enrollment.Facility = facility;
            enrollment.Start = command.Form.Start;
            enrollment.Comments = command.Form.Comments;
            enrollment.RowVersionId = Guid.NewGuid();

            return new WorkspaceEnrollmentUpdateComponentSubmitResult(
                enrollment.Id,
                enrollment.RowVersionId,
                enrollment.Number);
        }

        private async Task<Enrollment> GetOrCreateEnrollmentAsync(WorkspaceEnrollmentUpdateComponentSubmitCommand command, CancellationToken ct)
        {
            if (command.EnrollmentId.HasValue)
            {
                var enrollment = await _compass.Enrollments
                    .Include(e => e.Service)
                    .Include(e => e.Facility)
                    .Where(e => e.Id == command.EnrollmentId)
                    .FirstAsync(ct);

                Assert.RowVersionId(
                    enrollment.RowVersionId, 
                    command.EnrollmentRowVersionId!.Value);

                return enrollment;
            }

            var service = await _compass.Services
                .Where(s => s.Id == command.Form.ServiceId)
                .FirstAsync(ct);

            var facility = command.Form.FacilityId.HasValue
                ? await _compass.Facilities
                    .Where(f => f.Id == command.Form.FacilityId)
                    .FirstAsync(ct)
                : null;

            var sequence = await GetOrCreateSequenceAsync(
                $"{command.Creation.UtcDateTime.Year}/{service.Code}".ToUpper(),
                ct);

            sequence.NextValue += 1;
            sequence.RowVersionId = Guid.NewGuid();

            return _compass.Enrollments.Add(new()
            {
                Id = Guid.NewGuid(),
                RowVersionId = Guid.NewGuid(),
                Service = service,
                Number = $"{sequence.Name}/{sequence.NextValue}",
                Status = EnrollmentStatus.Draft,
                Creation = command.Creation
            })
                .Entity;
        }

        private async Task<Sequence> GetOrCreateSequenceAsync(string sequenceName, CancellationToken ct)
        {
            var sequence = await _compass.Sequences
                .Where(s => s.Name == sequenceName)
                .FirstOrDefaultAsync(ct);

            sequence ??= _compass.Sequences.Add(new()
            {
                Id = Guid.NewGuid(),
                RowVersionId = Guid.NewGuid(),
                Name = sequenceName,
                NextValue = 1
            })
                .Entity;

            return sequence;
        }
    }
}
