using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class ServiceDeleteDtoValidator : AbstractValidator<ServiceEditDTO>
    {
        public ServiceDeleteDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("CustomerId required");
        }
  

    }
}
