using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitCommandHandler : ICommandHandler<WorkspaceEnrollmentUpdateSubmitCommand, WorkspaceEnrollmentUpdateSubmitResult>
    {
        private readonly CompassContext _context;

        public WorkspaceEnrollmentUpdateSubmitCommandHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceEnrollmentUpdateSubmitResult> HandleCommandAsync(WorkspaceEnrollmentUpdateSubmitCommand command, CancellationToken ct)
        {
            var facility = await _context.Facilities
                .Where(f => f.Id == command.Form.FacilityId)
                .SingleAsync(ct);

            var service = await _context.Services
                .Where(s => s.Id == command.Form.ServiceId)
                .SingleAsync(ct);

            var enrollment = command.EnrollmentId.HasValue
                ? await _context.Enrollments
                    .Where(f => f.Id == command.EnrollmentId)
                    .FirstAsync(ct)
                : null;

            if (enrollment is null)
            {
                var sequenceName = $"{command.Creation.UtcDateTime.Year}/{service.Code}/{facility.Code}";

                var sequence = await _context.Sequences
                    .Where(s => s.Name == sequenceName)
                    .FirstOrDefaultAsync(ct);

                sequence ??= _context.Sequences.Add(new()
                {
                    Name = sequenceName,
                    LastNumber = 0
                })
                    .Entity;

                enrollment = _context.Enrollments.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Facility = facility,
                    Service = service,
                    Number = $"{sequence.Name}/{++sequence.LastNumber}",
                    Creation = command.Creation,
                    Start = command.Form.Start
                })
                    .Entity; 
            }

            enrollment.Start = command.Form.Start;
            enrollment.RowVersionId = Guid.NewGuid();

            return new WorkspaceEnrollmentUpdateSubmitResult(
                enrollment.Id,
                enrollment.RowVersionId,
                enrollment.Number);
        }
    }
}
