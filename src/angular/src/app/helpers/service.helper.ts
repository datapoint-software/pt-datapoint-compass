import { HttpErrorResponse, HttpStatusCode } from "@angular/common/http";
import { ErrorResponseModel } from "@app/services/service.abstractions";

const status = <T>(
  status: number,
  fn: (model: ErrorResponseModel, response: HttpErrorResponse) => Promise<T> | T
): ((error: unknown) => Promise<T>) => async (error) => {

  if (error instanceof HttpErrorResponse && error.status === status && error.headers.has("X-Compass-Host")) {
    const r = fn(error.error, error);
    if (r) await r;
    return r;
  }

  throw error;
}

export const conflict = <T>(
  fn: (model: ErrorResponseModel, response: HttpErrorResponse) => Promise<T> | T
): ((error: unknown) => Promise<T>) =>

  status(HttpStatusCode.Conflict, fn);

export const forbidden = <T>(
  fn: (model: ErrorResponseModel, response: HttpErrorResponse) => Promise<T> | T
): ((error: unknown) => Promise<T>) =>

  status(HttpStatusCode.Forbidden, fn);

export const unauthorized = <T>(
  fn: (model: ErrorResponseModel, response: HttpErrorResponse) => Promise<T> | T
): ((error: unknown) => Promise<T>) =>

  status(HttpStatusCode.Unauthorized, fn);
