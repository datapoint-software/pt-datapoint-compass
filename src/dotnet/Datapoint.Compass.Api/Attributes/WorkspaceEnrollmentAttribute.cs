using Datapoint.Compass.Enumerations;

namespace Datapoint.Compass.Api.Attributes
{
    public sealed class WorkspaceEnrollmentAttribute : WorkspaceAttribute
    {
        public WorkspaceEnrollmentAttribute() : base()
        {
            Roles = Permission.WorkspaceEnrollment.ToString("G");
        }
    }
}
