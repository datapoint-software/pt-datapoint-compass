export const ERROR_MESSAGE_TRANSLATIONS = new Map([
  [ "email", $localize `:@@sui-form-group-error-email:This field requires an email address.` ],
  [ "maxlength", $localize `:@@sui-form-group-error-maxlength:This field is too long.` ],
  [ "required", $localize `:@@sui-form-group-error-required:This field is required and can not be empty.` ],
  [ "unique", $localize `:@@sui-form-group-error-unique:This field must be unique and has already been assigned.` ]
]);

export const ERROR_MESSAGE_DEFAULT_TRANSLATION = $localize `:@@sui-form-group-error:This field is invalid.`;
