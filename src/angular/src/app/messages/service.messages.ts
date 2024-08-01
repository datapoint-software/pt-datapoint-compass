import { Service } from "@app/app.enums";

export const SERVICE_MESSAGES = new Map([
  [ Service.ActivityCenter, $localize `:@@service-activity-center:Activity Center` ],
  [ Service.Childcare, $localize `:@@service-childcare:Childcare` ],
]);
