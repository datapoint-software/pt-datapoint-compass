namespace Datapoint.Compass.Api.Components.Workspace.Home
{
    public sealed class WorkspaceHomeComponentModel
    {
        public WorkspaceHomeComponentModel(int? enrollmentCount)
        {
            EnrollmentCount = enrollmentCount;
        }

        public int? EnrollmentCount { get; }
    }
}
