import { Pipe, PipeTransform } from "@angular/core";
import { DocumentKind } from "@app/app.enums";

@Pipe({
  name: "documentKindLabel",
  pure: true,
  standalone: true
})
export class DocumentKindLabelPipe implements PipeTransform {

  transform(value: DocumentKind | null): string | null {

    if (!value)
      return null;

    return (
      value === DocumentKind.National ? $localize `:@@document-kind-national:Citizen Card` :
      value === DocumentKind.Passport ? $localize `:@@document-kind-passport:Passport` :
        null
    );
  }

}
