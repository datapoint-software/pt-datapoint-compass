import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { WorkspaceFacilityService } from "@app/services/workspace/facilities/workspace-facility.service";
import { WorkspaceFacilitySearchResultModel } from "@app/services/workspace/facilities/workspace-facility.service.abstractions";

export const workspaceFacilitySearchComponentResolveFn: ResolveFn<{
  results: WorkspaceFacilitySearchResultModel[];
  totalResultCount: number;
}> = async (route) => {

  const facilities = inject(WorkspaceFacilityService);

  const filter = route.queryParamMap.get("filter");
  const skip = route.queryParamMap.get("skip");
  const take = route.queryParamMap.get("take");

  return await facilities.getSearch({
    ...(filter ? { filter } : {}),
    ...(skip ? { skip } : {}),
    ...(take ? { take } : {})
  });
};
