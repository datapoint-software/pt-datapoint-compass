import { FormGroup } from "@angular/forms";
import { ErrorResponseModel } from "@app/api/api.abstractions";

export const applyErrorResponse = (fg: FormGroup, response: ErrorResponseModel, ns: string | null = "form") => {

  if (!ns?.includes('.'))
    fg.setErrors({ response });

  if (!response.innerErrors)
    return;

  for (const formControlName of Object.keys(fg.controls)) {

    const formControl = fg.controls[formControlName];
    const prefix = ns ? `${ns}.` : '';
    const cns = `${prefix}${formControlName}`;

    if (formControl instanceof FormGroup) {
      applyErrorResponse(formControl, response, cns);
      continue;
    }

    response.innerErrors
      .filter(e => e.propertyName === cns)
      .forEach(e => formControl.setErrors({ [ e.name ]: true }));
  }
};

export const ensureEnum = <T>(value: T | string | number | null): T | null => {

  if (!value)
    return null;

  if ("string" === typeof(value))
    return parseInt(value) as T;

  return value as T;
};

export const fromValueOf = (fg: { value: { [k: string]: unknown } }): any => {

  const prune = (value: { [k: string]: unknown }) => {
    for (let k in value)
      if (!value[k])
        delete value[k];
      else if (value[k] instanceof Array)
        value[k] = value[k].filter(v => !!v);
      else if ("object" === typeof value[k])
        value[k] = prune(value[k] as {});
    return value;
  };

  return prune(fg.value);
};
