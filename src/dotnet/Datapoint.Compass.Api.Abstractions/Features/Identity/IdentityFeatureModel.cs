using Datapoint.Compass.Enumerations;
using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Features.Identity
{
    public sealed class IdentityFeatureModel
    {
        public IdentityFeatureModel(Guid? id, string? name, string? emailAddress, IdentityKind kind, IEnumerable<Permission> permissions, DateTimeOffset? expiration)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            Kind = kind;
            Permissions = permissions;
            Expiration = expiration;
        }

        public Guid? Id { get; }

        public string? Name { get; }

        public string? EmailAddress { get; }

        public IdentityKind Kind { get; }

        public IEnumerable<Permission> Permissions { get; }

        public DateTimeOffset? Expiration { get; }
    }
}
