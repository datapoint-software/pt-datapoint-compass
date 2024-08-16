import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, inject } from "@angular/core";
import { Params, Router } from "@angular/router";

export class AppErrorHandler implements ErrorHandler {

  private readonly _router: Router = inject(Router);

  handleError(error: any): void {

    console.error ? console.error(error) :
      console.warn ? console.warn(error) :
        console.log(error);

    const queryParams: Params = {};

    if (error instanceof HttpErrorResponse) {

      const compass = error.headers.has("X-Compass-Environment");

      queryParams["status"] = compass
        ? error.status
        : "503";
    }

    this._router.navigate([
      "/error"
    ], {
      queryParams
    });
  }
}
