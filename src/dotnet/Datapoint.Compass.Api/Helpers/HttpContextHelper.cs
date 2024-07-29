using Microsoft.AspNetCore.Http;
using System.Net;

namespace Datapoint.Compass.Api.Helpers
{
    internal static class HttpContextHelper
    {
        internal static IPAddress GetRemoteAddress(this HttpContext httpContext)
        {
            var remoteAddressAsString = httpContext.Request.Headers["X-Forwarded-For"].ToString();

            if (string.IsNullOrEmpty(remoteAddressAsString))
            {
                if (httpContext.Connection.RemoteIpAddress is null)
                    throw new AuthenticationException("Remote network address is not set.");

                return httpContext.Connection.RemoteIpAddress;
            }

            if (!IPAddress.TryParse(remoteAddressAsString, out var remoteAddress))
                throw new AuthenticationException("Remote network address is invalid.");

            return remoteAddress;
        }

        internal static string GetUserAgent(this HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers.UserAgent.ToString();

            if (string.IsNullOrEmpty(userAgent))
                throw new AuthenticationException("User agent is not set.");

            return userAgent;
        }
    }
}
