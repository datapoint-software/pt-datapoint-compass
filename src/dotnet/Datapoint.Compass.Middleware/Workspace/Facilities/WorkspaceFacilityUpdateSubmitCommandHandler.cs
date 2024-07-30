using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateSubmitCommandHandler : ICommandHandler<WorkspaceFacilityUpdateSubmitCommand, WorkspaceFacilityUpdateSubmitResult>
    {
        private readonly CompassContext _context;

        public WorkspaceFacilityUpdateSubmitCommandHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceFacilityUpdateSubmitResult> HandleCommandAsync(WorkspaceFacilityUpdateSubmitCommand command, CancellationToken ct)
        {
            var facility = command.FacilityId.HasValue
                ? await _context.Facilities
                    .Where(f => f.Id == command.FacilityId)
                    .FirstAsync(ct)
                : null;

            var errors = new List<Error>();

            if (facility is null)
            {
                await errors.AddWhenAsync("unique", "Form.Code", _context.Facilities
                    .Where(f => f.Code == command.Form.Code)
                    .AnyAsync(ct));

                await errors.AddWhenAsync("unique", "Form.Name", _context.Facilities
                    .Where(f => f.Name == command.Form.Name)
                    .AnyAsync(ct));

                facility = _context.Facilities.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Code = command.Form.Code
                })
                    .Entity;
            }
            else
            {
                Assert.NotNull(command.FacilityRowVersionId);
                Assert.RowVersionId(facility.RowVersionId, command.FacilityRowVersionId.Value);

                await errors.AddWhenAsync("unique", "Form.Name", _context.Facilities
                    .Where(f => f.Name == command.Form.Name)
                    .Where(f => f.Id != facility.Id)
                    .AnyAsync(ct));
            }

            if (errors.Count > 0)
                throw new BusinessException("Business validation failure.")
                    .AddInnerErrors(errors);

            facility.Name = command.Form.Name;
            facility.Description = command.Form.Description;
            facility.RowVersionId = Guid.NewGuid();

            return new WorkspaceFacilityUpdateSubmitResult(
                facility.Id,
                facility.RowVersionId);
        }
    }
}
