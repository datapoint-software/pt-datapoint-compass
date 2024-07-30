export type WorkspaceFacilityUpdateFormModel = {
  code: string;
  name: string;
  description?: string;
};

export type WorkspaceFacilityUpdateModel = {
  facilityId?: string;
  facilityRowVersionId?: string;
  form?: WorkspaceFacilityUpdateFormModel;
};

export type WorkspaceFacilitySearchModel = {
  results: WorkspaceFacilitySearchResultModel[];
  totalResultCount: number;
};

export type WorkspaceFacilitySearchResultModel = {
  id: string;
  code: string;
  name: string;
  description?: string;
};

export type WorkspaceFacilityUpdateSubmitModel = {
  facilityId?: string;
  facilityRowVersionId?: string;
  form: WorkspaceFacilityUpdateFormModel;
};

export type WorkspaceFacilityUpdateSubmitResultModel = {
  facilityId: string;
  facilityRowVersionId: string;
};
