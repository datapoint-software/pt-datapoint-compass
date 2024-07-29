import { IdentityKind, Permission } from "@app/app.enums";

export type IdentityModel = {
  id: string;
  name: string;
  emailAddress: string;
  kind: IdentityKind;
  permissions: Permission[];
  expiration?: string;
};

export type IdentitySignInModel = {
  emailAddress: string;
  password: string;
  rememberMe: boolean;
};
