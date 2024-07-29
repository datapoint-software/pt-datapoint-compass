using Datapoint.Mediator;
using Datapoint.Mediator.Attributes;
using System.Net;

namespace Datapoint.Compass.Middleware.Identities
{
    public sealed class IdentitySignInCommand : Command<Identity>
    {
        public IdentitySignInCommand(IPAddress remoteAddress, string userAgent, string emailAddress, string password, bool rememberMe)
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

        [Sensitive]
        public string Password { get; }

        public bool RememberMe { get; }
    }
}
