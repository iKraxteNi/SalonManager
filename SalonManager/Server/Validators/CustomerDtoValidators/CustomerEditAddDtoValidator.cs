using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class CustomerEditAddDtoValidator : AbstractValidator<CustomerEditDTO>
    {
        public CustomerEditAddDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName required");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber required");

        }
    }
}
