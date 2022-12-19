using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class CustomerDeleteDtoValidator : AbstractValidator<CustomerEditDTO>
    {
        public CustomerDeleteDtoValidator()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("Name required");

  

    }
}
