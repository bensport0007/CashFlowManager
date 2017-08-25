using FluentValidation;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public static class SeverityExtender
    {
        public static ValidationSeverity ToValidationSeverity(this Severity severity)
        {
            switch (severity)
            {
                case Severity.Error: return ValidationSeverity.Error;
                case Severity.Warning: return ValidationSeverity.Warning;
                case Severity.Info: return ValidationSeverity.Info;
                default: return ValidationSeverity.Unkown;
            }
        }
    }
}