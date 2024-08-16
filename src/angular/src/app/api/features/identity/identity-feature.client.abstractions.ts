import { IdentityKind, Permission } from "@app/app.enums";

export type IdentityFeatureModel = {
  id?: string;
  name?: string;
  emailAddress?: string;
  kind: IdentityKind;
  permissions: Permission[];
  expiration?: string;
};

export type IdentityFeatureSignInModel = {
  emailAddress: string;
  password: string;
  rememberMe: boolean;
};
