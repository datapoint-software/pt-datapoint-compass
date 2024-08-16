using Datapoint.Compass.Enumerations;
using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeature
    {
        public IdentityFeature(Guid? id, Guid? sessionId, string? name, string? emailAddress, IdentityKind kind, IEnumerable<Permission> permissions, DateTimeOffset? expiration)
        {
            Id = id;
            SessionId = sessionId;
            Name = name;
            EmailAddress = emailAddress;
            Kind = kind;
            Permissions = permissions;
            Expiration = expiration;
        }

        public Guid? Id { get; }

        public Guid? SessionId { get; }

        public string? Name { get; }

        public string? EmailAddress { get; }

        public IdentityKind Kind { get; }

        public IEnumerable<Permission> Permissions { get; }

        public DateTimeOffset? Expiration { get; }
    }
}