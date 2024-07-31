export type WorkspaceServiceUpdateFormModel = {
  code: string;
  name: string;
  description?: string;
};

export type WorkspaceServiceUpdateModel = {
  serviceId?: string;
  serviceRowVersionId?: string;
  form?: WorkspaceServiceUpdateFormModel;
};

export type WorkspaceServiceSearchModel = {
  results: WorkspaceServiceSearchResultModel[];
  totalResultCount: number;
};

export type WorkspaceServiceSearchResultModel = {
  id: string;
  code: string;
  name: string;
  description?: string;
};

export type WorkspaceServiceUpdateSubmitModel = {
  serviceId?: string;
  serviceRowVersionId?: string;
  form: WorkspaceServiceUpdateFormModel;
};

export type WorkspaceServiceUpdateSubmitResultModel = {
  serviceId: string;
  serviceRowVersionId: string;
};
