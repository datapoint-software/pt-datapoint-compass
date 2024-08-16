import { Pipe, PipeTransform } from "@angular/core";
import { EnrollmentStatus } from "@app/app.enums";

const ENROLLMENT_STATUS_MESSAGES = new Map([
  [ EnrollmentStatus.Draft, $localize `:@@enrollment-status-draft:Draft` ]
]);

@Pipe({
  name: "enrollmentStatusLabel",
  standalone: true
})
export class EnrollmentStatusLabelPipe implements PipeTransform {

  transform(value: EnrollmentStatus | null): string | null {

    if (!value)
      return null;

    const translation = ENROLLMENT_STATUS_MESSAGES.get(value);

    if (!translation)
      throw new Error("Enrollment status is not supported.");;

    return translation;
  }

}
