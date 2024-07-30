import { inject } from "@angular/core";
import { Params, ResolveFn } from "@angular/router";
import { WorkspaceFacilityService } from "@app/services/workspace/facilities/workspace-facility.service";
import { WorkspaceFacilityUpdateModel } from "@app/services/workspace/facilities/workspace-facility.service.abstractions";

export const workspaceFacilityUpdateComponentResolveFn: ResolveFn<WorkspaceFacilityUpdateModel> = (route) => {

  const facilities = inject(WorkspaceFacilityService);

  const facilityId = route.paramMap.get("facilityId");

  return facilities.getUpdate({
    ...(facilityId ? ({ facilityId }) : {})
  });
};
