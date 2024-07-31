export type WorkspaceEnrollmentUpdateModel = {
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  facilities: WorkspaceEnrollmentFacilityModel[];
  services: WorkspaceEnrollmentServiceModel[];
  form?: WorkspaceEnrollmentUpdateFormModel;
};

export type WorkspaceEnrollmentFacilityModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentServiceModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentUpdateFormModel = {

};

export type WorkspaceEnrollmentUpdateSubmitModel = {
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  form: WorkspaceEnrollmentUpdateFormModel;
};

export type WorkspaceEnrollmentUpdateSubmitResultModel = {
  enrollmentId: string;
  enrollmentRowVersionId: string;
  number: string;
};
