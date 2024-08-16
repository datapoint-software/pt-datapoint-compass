import { EnrollmentStatus } from "@app/app.enums";

export type WorkspaceEnrollmentSearchComponentFacilityModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentSearchComponentModel = {
  services: WorkspaceEnrollmentSearchComponentServiceModel[];
  facilities: WorkspaceEnrollmentSearchComponentFacilityModel[];
};

export type WorkspaceEnrollmentSearchComponentSearchModel = {
  filter?: string;
  serviceId?: string;
  facilityId?: string;
  status?: EnrollmentStatus;
  skip?: number;
  take?: number;
};

export type WorkspaceEnrollmentSearchComponentSearchResultMatchModel = {
  id: string;
  serviceId: string;
  facilityId?: string;
  number: string;
  status: EnrollmentStatus;
  creation: string;
  start?: string;
};

export type WorkspaceEnrollmentSearchComponentSearchResultModel = {
  totalMatchCount: number;
  matches: WorkspaceEnrollmentSearchComponentSearchResultMatchModel[];
};

export type WorkspaceEnrollmentSearchComponentServiceModel = {
  id: string;
  name: string;
};
