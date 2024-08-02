import { MaritalStatus } from "@app/app.enums";

export const MARITAL_STATUS_MESSAGES = new Map([
  [ MaritalStatus.Divorced, $localize `:@@marital-status-divorced:Divorced` ],
  [ MaritalStatus.Married, $localize `:@@marital-status-married:Married` ],
  [ MaritalStatus.Single, $localize `:@@marital-status-single:Single` ]
]);
