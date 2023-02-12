using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class CustomerEditAddDtoValidator : AbstractValidator<CustomerEditDTO>
    {
        public CustomerEditAddDtoValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty().WithMessage("Name required");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Price required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Duration required").MinimumLength(9);

        }
    }
}
