import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "avatarLabel",
  pure: true,
  standalone: true
})
export class AvatarLabelPipe implements PipeTransform {

  transform(name: string): string | null {

    const tokens = name.split(" ")
      .filter(token => !!token);

    if (tokens.length > 0) {

      let label = tokens[0][0].toUpperCase();

      if (tokens.length > 1)
        label += tokens[tokens.length - 1][0].toUpperCase();

      return label;
    }

    return null;
  }
}
