import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { WorkspaceEnrollmentService } from "@app/services/workspace/enrollments/workspace-enrollment.service";
import { WorkspaceEnrollmentUpdateModel } from "@app/services/workspace/enrollments/workspace-enrollment.service.abstractions";

export const workspaceEnrollmentUpdateComponentResolveFn: ResolveFn<WorkspaceEnrollmentUpdateModel> = (route) => {

  const enrollmentId = route.paramMap.get("enrollmentId");

  return inject(WorkspaceEnrollmentService).getUpdate({
    ...(enrollmentId ? { enrollmentId } : {})
  });
};
