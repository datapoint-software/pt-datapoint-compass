export type WorkspaceEnrollmentUpdateComponentFacilityModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentUpdateComponentFormModel = {
  serviceId?: string;
  facilityId?: string;
  enrollment?: string;
  comments?: string;
};

export type WorkspaceEnrollmentUpdateComponentModel = {
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  countryCode: string;
  districtCode?: string;
  facilities: WorkspaceEnrollmentUpdateComponentFacilityModel[];
  services: WorkspaceEnrollmentUpdateComponentServiceModel[];
  number?: string;
  form?: WorkspaceEnrollmentUpdateComponentFormModel;
};

export type WorkspaceEnrollmentUpdateComponentServiceModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentUpdateComponentSubmitModel = {
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  form: WorkspaceEnrollmentUpdateComponentFormModel;
};

export type WorkspaceEnrollmentUpdateComponentSubmitResultModel = {
  enrollmentId: string;
  enrollmentRowVersionId: string;
  number: string;
};
