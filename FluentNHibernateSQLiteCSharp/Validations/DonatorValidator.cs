using System.Linq;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Properties;
using FluentValidation;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public class DonatorValidator : AbstractValidator<Donator>, IDonatorValidator
    {
        public DonatorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Must(NotContainAnyNumber)
                .WithMessage(Resources.DonatorValidator_FirstName)
                .WithSeverity(Severity.Error);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Must(NotContainAnyNumber)
                .WithMessage(Resources.DonatorValidator_LastName)
                .WithSeverity(Severity.Error);
        }

        private bool NotContainAnyNumber(string stringToValidate)
        {
            return !stringToValidate.Any(char.IsDigit);
        }
    }
}