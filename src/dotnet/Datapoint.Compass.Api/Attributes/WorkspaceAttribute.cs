using Microsoft.AspNetCore.Authorization;

namespace Datapoint.Compass.Api.Attributes
{
    public class WorkspaceAttribute : AuthorizeAttribute
    {
        public WorkspaceAttribute() : base("Employee")
        {

        }
    }
}
