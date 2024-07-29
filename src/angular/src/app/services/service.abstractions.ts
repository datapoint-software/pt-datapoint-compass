export type ErrorResponseModel = {
  id?: string;
  correlationId?: string;
  name?: string;
  message: string;
  innerErrors?: ErrorModel[];
  stackTrace?: string;
};

export type ErrorModel = {
  name: string;
  propertyName?: string;
  message?: string;
};
