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
