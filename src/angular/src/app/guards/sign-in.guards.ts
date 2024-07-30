import { CanActivateFn } from "@angular/router";
import { pre } from "@app/app.pre";

export const signInCanActivateFn: CanActivateFn = async () => {

  await pre({
    images: [
      "assets/dashly/images/illustrations/sign-in-illustration.svg"
    ]
  });

  return true;

};
