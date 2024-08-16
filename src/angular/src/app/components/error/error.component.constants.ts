export const STATUS_CODE_DESCRIPTIONS = new Map([
  [ "403", $localize `:@@error-message-forbidden:Sorry, you do not have sufficient permissions to access the resource at this location.` ],
  [ "404", $localize `:@@error-message-not-found:The document you are looking does not exist or may have been moved to a different location.`],
  [ "503", $localize `:@@error-message-service-unavailable:Our services are currently unavailable and undergoing maintenance, please try again within a few moments.`]
]);

export const STATUS_CODE_TITLES = new Map([
  [ "403", $localize `:@@error-title-forbidden:Forbidden` ],
  [ "404", $localize `:@@error-title-not-found:Document not found` ],
  [ "503", $localize `:@@error-title-service-unavailable:Service unavailable`]
]);
