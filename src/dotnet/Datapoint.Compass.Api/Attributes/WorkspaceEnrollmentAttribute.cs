using Datapoint.Compass.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace Datapoint.Compass.Api.Attributes
{
    public sealed class WorkspaceEnrollmentAttribute : AuthorizeAttribute
    {
        public WorkspaceEnrollmentAttribute()
        {
            Roles = Permission.WorkspaceEnrollments.ToString("G");
        }
    }
}
