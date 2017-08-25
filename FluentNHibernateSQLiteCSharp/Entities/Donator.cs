using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using FluentNHibernateSQLiteCSharp.Validations;
using FluentValidation.Results;

namespace FluentNHibernateSQLiteCSharp.Entities
{
    public class Donator : BaseEntity, IDonator, ICanValidate
    {
        private readonly IDonatorValidator _donatorValidator;

        public Donator() {}

        public Donator(IDonatorValidator donatorValidator)
        {
            _donatorValidator = donatorValidator;
        }

        public virtual int Id { get; protected set; }
        public virtual int Number { get; set; } //We're reusing donator numbers so it can't be the id
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual ValidationResult Validate()
        {
            return _donatorValidator.Validate(this);
        }
    }
}