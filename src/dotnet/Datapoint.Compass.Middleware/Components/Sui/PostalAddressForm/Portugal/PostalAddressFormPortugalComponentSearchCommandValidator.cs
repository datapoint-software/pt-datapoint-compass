using FluentValidation;
using System.Text.RegularExpressions;

namespace Datapoint.Compass.Middleware.Components.Sui.PostalAddressForm.Portugal
{
    public sealed class PostalAddressFormPortugalComponentSearchCommandValidator : AbstractValidator<PostalAddressFormPortugalComponentSearchCommand>
    {
        private static readonly Regex PortugueseAreaCode = new Regex(@"^\d{4}\-\d{3}$", RegexOptions.Compiled);

        public PostalAddressFormPortugalComponentSearchCommandValidator()
        {
            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .Matches(PortugueseAreaCode);
        }
    }
}
