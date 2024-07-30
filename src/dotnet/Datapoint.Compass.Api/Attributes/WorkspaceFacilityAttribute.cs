using Datapoint.Compass.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace Datapoint.Compass.Api.Attributes
{
    public sealed class WorkspaceFacilityAttribute : AuthorizeAttribute
    {
        public WorkspaceFacilityAttribute() : base ()
        {
            Roles = Permission.WorkspaceFacilities.ToString();
        }
    }
}
