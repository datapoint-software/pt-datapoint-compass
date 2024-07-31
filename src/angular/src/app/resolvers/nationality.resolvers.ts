import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { APP_LOCALE } from "@app/app.constants";
import { NationalityService } from "@app/services/nationalities/nationality.service";
import { NationalityModel } from "@app/services/nationalities/nationality.service.abstractions";

export const nationalityArrayResolveFn: ResolveFn<NationalityModel[]> = () =>
  inject(NationalityService).getAll({ locale: APP_LOCALE });
