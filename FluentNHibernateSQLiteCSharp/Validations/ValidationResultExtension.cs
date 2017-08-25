using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public static class ValidationResultExtension
    {
        public static ValidationFailuresDto ToValidationFailureDto(this ValidationFailure validationFailure)
        {
            return new ValidationFailuresDto
            {
                Severity = (ValidationSeverity) validationFailure.Severity,
                ErrorCode = validationFailure.ErrorCode,
                Message = validationFailure.ErrorMessage
            };
        }
    }
}