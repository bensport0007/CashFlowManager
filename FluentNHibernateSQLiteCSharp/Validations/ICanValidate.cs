using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public interface ICanValidate
    {
        ValidationResult Validate();
    }
}