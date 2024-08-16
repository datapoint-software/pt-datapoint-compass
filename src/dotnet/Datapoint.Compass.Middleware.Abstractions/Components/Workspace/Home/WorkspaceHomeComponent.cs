namespace Datapoint.Compass.Middleware.Components.Workspace.Home
{
    public sealed class WorkspaceHomeComponent
    {
        public WorkspaceHomeComponent(int? enrollmentCount)
        {
            EnrollmentCount = enrollmentCount;
        }

        public int? EnrollmentCount { get; }
    }
}
