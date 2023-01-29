using FluentValidation;
using PersonManagement.Application.Contracts;
using System.ComponentModel;

namespace PersonManagement.WebApi.Validations
{
    public class CreatePersonModelValidator : AbstractValidator<CreatePersonModel>
    {
        public CreatePersonModelValidator() 
        {
            RuleFor(s => s.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .Matches("^([a-zA-Z]+|[ა-ჰ]+)$")
                .WithMessage("The FirstName must contain english or Georgian characters only but not both at the same time");
            RuleFor(s => s.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .Matches("^([a-zA-Z]+|[ა-ჰ]+)$")
                .WithMessage("The LastName must contain english or Georgian characters only but not both at the same time");
            RuleFor(s => s.PersonalNumber)
                .NotEmpty()
                .MaximumLength(11);
            RuleFor(s => s.DateOfBirth)
                .NotEmpty()
                .Must(BeAtLeast18YearsOld)                 
                .WithMessage("Must be minimum 18 years old");

            RuleForEach(r => r.Phones).SetValidator(new PhoneValidator());
        }

        private bool BeAtLeast18YearsOld(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Today.AddYears(-18);
        }
    }
}
