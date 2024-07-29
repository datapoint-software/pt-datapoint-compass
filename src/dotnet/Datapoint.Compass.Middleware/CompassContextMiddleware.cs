using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware
{
    internal sealed class CompassContextMiddleware : IMiddleware
    {
        private readonly CompassContext _compass;

        public CompassContextMiddleware(CompassContext compass) =>
            _compass = compass;

        public async Task HandleCommandAsync<TCommand>(TCommand command, Func<TCommand, Task> next, CancellationToken ct) where TCommand : ICommand
        {
            await next(command);
            await _compass.SaveChangesAsync(ct);
        }

        public async Task<TCommandResult> HandleCommandAsync<TCommand, TCommandResult>(TCommand command, Func<TCommand, Task<TCommandResult>> next, CancellationToken ct) where TCommand : ICommand<TCommandResult>
        {
            var result = await next(command);
            await _compass.SaveChangesAsync(ct);
            return result;
        }

        public Task HandleMessageAsync<TMessage>(TMessage message, Func<TMessage, Task> next, CancellationToken ct) where TMessage : IMessage =>
            
            next(message);

        public Task<TQueryResult> HandleQueryAsync<TQuery, TQueryResult>(TQuery query, Func<TQuery, Task<TQueryResult>> next, CancellationToken ct) where TQuery : IQuery<TQueryResult> =>
            
            next(query);
    }
}
