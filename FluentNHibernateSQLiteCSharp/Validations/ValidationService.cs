using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Services;
using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Validations
{
    public class ValidationService : IValidationService
    {
        public IList<ValidationFailuresDto> ValidateObjectList(IEnumerable<object> objectsToValidateList)
        {
            IList<ValidationFailuresDto> validationFailures = new List<ValidationFailuresDto>();

            foreach (var objectToValidate in objectsToValidateList)
            {
                var validationResult = ValidateObject(objectToValidate);
                if (!validationResult.IsValid)
                    AddValidationResult(validationResult, validationFailures);
            }

            return validationFailures;
        }

        public ValidationResult ValidateObject(object objectToValidate)
        {
            var validationResult = new ValidationResult();

            var objectThatCanValidate = objectToValidate as ICanValidate;
            if (objectThatCanValidate != null)
                validationResult = objectThatCanValidate.Validate();

            return validationResult;
        }

        private static void AddValidationResult(ValidationResult validationResult,
            ICollection<ValidationFailuresDto> validationFailures)
        {
            foreach (var failure in validationResult.Errors)
                validationFailures.Add(failure.ToValidationFailureDto());
        }
    }
}