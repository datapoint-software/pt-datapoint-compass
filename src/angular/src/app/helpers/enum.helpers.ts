export const  optionsOf = <T extends { [k: string]: number | string }>(t: T): (T[keyof T])[] =>
  Object.values(t).filter((value) => "number" === typeof value) as unknown as (T[keyof T])[];
