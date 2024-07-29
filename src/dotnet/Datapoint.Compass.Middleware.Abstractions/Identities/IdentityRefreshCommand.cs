using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Identities
{
    public sealed class IdentityRefreshCommand : Command<Identity>
    {
        public IdentityRefreshCommand(Guid identitySessionId, IdentityKind identityKind, DateTimeOffset? expiration)
        {
            IdentitySessionId = identitySessionId;
            IdentityKind = identityKind;
            Expiration = expiration;
        }

        public Guid IdentitySessionId { get; }

        public IdentityKind IdentityKind { get; }

        public DateTimeOffset? Expiration { get; }
    }
}
