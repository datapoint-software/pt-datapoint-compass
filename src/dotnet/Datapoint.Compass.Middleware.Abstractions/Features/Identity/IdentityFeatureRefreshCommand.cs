using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeatureRefreshCommand : Command<IdentityFeature>
    {
        public IdentityFeatureRefreshCommand(IdentityKind identityKind, Guid? identitySessionId)
        {
            IdentityKind = identityKind;
            IdentitySessionId = identitySessionId;
        }

        public IdentityKind IdentityKind { get; }

        public Guid? IdentitySessionId { get; }
    }
}
