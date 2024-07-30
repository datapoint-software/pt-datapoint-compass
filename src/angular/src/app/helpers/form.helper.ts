import { FormGroup } from "@angular/forms";
import { ErrorResponseModel } from "@app/services/service.abstractions";

export const applyErrorResponse = (fg: FormGroup, response: ErrorResponseModel, ns: string | null = "form") => {

  if (!ns?.includes('.'))
    fg.setErrors({ response });

  if (!response.innerErrors)
    return;

  for (const formControlName in Object.keys(fg.controls)) {

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

export const fromValueOf = (fg: { value: { [k: string]: unknown }}): any => {

  const prune = (value: { [k: string]: unknown }) => {
    for (let k in value)
      if (!value[k])
        delete value[k];
      else if ("object" === typeof value[k])
        value[k] = prune(value[k] as {});
    return value;
  };

  return prune(fg.value);
};
