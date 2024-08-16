using Datapoint.Mediator;
using System.Net;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeatureSignInCommand : Command<IdentityFeature>
    {
        public IdentityFeatureSignInCommand(IPAddress remoteAddress, string userAgent, string emailAddress, string password, bool rememberMe)
        {
            RemoteAddress = remoteAddress;
            UserAgent = userAgent;
            EmailAddress = emailAddress;
            Password = password;
            RememberMe = rememberMe;
        }

        public IPAddress RemoteAddress { get; }

        public string UserAgent { get; }

        public string EmailAddress { get; }

        public string Password { get; }

        public bool RememberMe { get; }
    }
}
