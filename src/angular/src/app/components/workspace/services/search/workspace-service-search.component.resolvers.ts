import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { WorkspaceServiceService } from "@app/services/workspace/services/workspace-service.service";
import { WorkspaceServiceSearchResultModel } from "@app/services/workspace/services/workspace-service.service.abstractions";

export const workspaceServiceSearchComponentResolveFn: ResolveFn<{
  results: WorkspaceServiceSearchResultModel[];
  totalResultCount: number;
}> = async (route) => {

  const services = inject(WorkspaceServiceService);

  const filter = route.queryParamMap.get("filter");
  const skip = route.queryParamMap.get("skip");
  const take = route.queryParamMap.get("take");

  return await services.getSearch({
    ...(filter ? { filter } : {}),
    ...(skip ? { skip } : {}),
    ...(take ? { take } : {})
  });
};
