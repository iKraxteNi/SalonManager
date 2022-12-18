using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class CustomerDeleteDtoValidator : AbstractValidator<CustomerEditDTO>
    {
        public CustomerDeleteDtoValidator()
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
