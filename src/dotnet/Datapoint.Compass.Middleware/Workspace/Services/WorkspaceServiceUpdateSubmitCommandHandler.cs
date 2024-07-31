using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitCommandHandler : ICommandHandler<WorkspaceServiceUpdateSubmitCommand, WorkspaceServiceUpdateSubmitResult>
    {
        private readonly CompassContext _context;

        public WorkspaceServiceUpdateSubmitCommandHandler(CompassContext context)
        {
            _context = context;
        }

        public async Task<WorkspaceServiceUpdateSubmitResult> HandleCommandAsync(WorkspaceServiceUpdateSubmitCommand command, CancellationToken ct)
        {
            var facility = command.ServiceId.HasValue
                ? await _context.Services
                    .Where(f => f.Id == command.ServiceId)
                    .FirstAsync(ct)
                : null;

            var errors = new List<Error>();

            if (facility is null)
            {
                await errors.AddWhenAsync("unique", "Form.Code", _context.Services
                    .Where(f => f.Code == command.Form.Code)
                    .AnyAsync(ct));

                await errors.AddWhenAsync("unique", "Form.Name", _context.Services
                    .Where(f => f.Name == command.Form.Name)
                    .AnyAsync(ct));

                facility = _context.Services.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Code = command.Form.Code
                })
                    .Entity;
            }
            else
            {
                Assert.NotNull(command.ServiceRowVersionId);
                Assert.RowVersionId(facility.RowVersionId, command.ServiceRowVersionId.Value);

                await errors.AddWhenAsync("unique", "Form.Name", _context.Services
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

            return new WorkspaceServiceUpdateSubmitResult(
                facility.Id,
                facility.RowVersionId);
        }
    }
}
