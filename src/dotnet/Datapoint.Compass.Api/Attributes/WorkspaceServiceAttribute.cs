using Datapoint.Compass.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace Datapoint.Compass.Api.Attributes
{
    public sealed class WorkspaceServiceAttribute : AuthorizeAttribute
    {
        public WorkspaceServiceAttribute() : base ()
        {
            Roles = Permission.WorkspaceFacilities.ToString();
        }
    }
}
