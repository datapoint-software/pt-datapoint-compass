export type WorkspaceEnrollmentUpdateModel = {
  enrollmentId?: string;
  enrollmentRowVersionId?: string;
  facilities: WorkspaceEnrollmentFacilityModel[];
  form?: WorkspaceEnrollmentUpdateFormModel;
};

export type WorkspaceEnrollmentFacilityModel = {
  id: string;
  name: string;
};

export type WorkspaceEnrollmentUpdateFormModel = {

};
