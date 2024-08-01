import { Pipe, PipeTransform } from "@angular/core";
import { Service } from "@app/app.enums";
import { SERVICE_MESSAGES } from "@app/messages/service.messages";

@Pipe({
  name: "serviceLabel",
  standalone: true
})
export class ServiceLabelPipe implements PipeTransform {

  transform(service: Service | null): string | null {

    if (!service)
      return null;

    const translation = SERVICE_MESSAGES.get(service);

    if (!translation)
      throw new Error("Service is not supported.");

    return translation;
  }
}
