using FluentValidation.Validators;
using FluentValidation;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class LanguageCodeHelper
    {
        internal static readonly string DefaultLanguageCode = "en";

        internal static readonly ISet<string> LanguageCodes = new HashSet<string>()
        {
            { DefaultLanguageCode },
            { "pt" }
        };

        internal static IRuleBuilderOptions<T, string?> LanguageCode<T>(this IRuleBuilder<T, string?> ruleBuilder) => ruleBuilder

            .Must((languageCode) =>
            {
                if (string.IsNullOrEmpty(languageCode))
                    return true;

                return LanguageCodes.Contains(languageCode);
            })

            .WithErrorCode("languagecode")
            .WithMessage("Property '{propertyName}' is not a known language code.");
    }
}
