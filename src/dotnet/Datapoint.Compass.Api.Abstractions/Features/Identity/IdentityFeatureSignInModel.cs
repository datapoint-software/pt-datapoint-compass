namespace Datapoint.Compass.Api.Features.Identity
{
    public sealed class IdentityFeatureSignInModel
    {
        public IdentityFeatureSignInModel(string emailAddress, string password, bool rememberMe)
        {
            EmailAddress = emailAddress;
            Password = password;
            RememberMe = rememberMe;
        }

        public string EmailAddress { get; }

        public string Password { get; }

        public bool RememberMe { get; }
    }
}
