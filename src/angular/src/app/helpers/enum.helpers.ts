export const  optionsOf = <T extends { [k: string]: number | string }>(t: T): (T[keyof T])[] =>
  Object.values(t).filter((value) => "number" === typeof value) as unknown as (T[keyof T])[];

export const optionOf = <T extends { [k: string]: number | string }>(t: T, value: string | number | null | undefined): (T[keyof T]) | null => {

  if (!value)
    return null;

  if ("string" === typeof(value))
    value = parseInt(value);

  return value as T[keyof T];
}
