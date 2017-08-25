using FluentNHibernateSQLiteCSharp.Entities;
using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public interface IDonatorValidator
    {
        ValidationResult Validate(Donator instance);
    }
}