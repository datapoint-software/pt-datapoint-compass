import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { WorkspaceServiceService } from "@app/services/workspace/services/workspace-service.service";
import { WorkspaceServiceUpdateModel } from "@app/services/workspace/services/workspace-service.service.abstractions";

export const workspaceServiceUpdateComponentResolveFn: ResolveFn<WorkspaceServiceUpdateModel> = (route) => {

  const services = inject(WorkspaceServiceService);

  const serviceId = route.paramMap.get("serviceId");

  return services.getUpdate({
    ...(serviceId ? ({ serviceId }) : {})
  });
};
