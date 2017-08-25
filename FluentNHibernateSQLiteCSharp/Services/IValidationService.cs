using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Validations;
using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface IValidationService
    {
        IList<ValidationFailuresDto> ValidateObjectList(IEnumerable<object> objectsToValidateList);
        ValidationResult ValidateObject(object objectToValidate);
    }
}