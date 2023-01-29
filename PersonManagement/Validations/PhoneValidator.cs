using FluentValidation;
using PersonManagement.Application.Contracts;

namespace PersonManagement.WebApi.Validations
{
    public class PhoneValidator : AbstractValidator<PhoneModel>
    {
        public PhoneValidator()
        {
            RuleFor(s => s.PhoneNumber)
                .MinimumLength(4)
                .MaximumLength(50);
        }
    }
}
