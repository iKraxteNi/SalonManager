using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.CustomerDtoValidators
{
    public class ServicerEditAddDtoValidator : AbstractValidator<ServiceEditDTO>
    {
        public ServicerEditAddDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price required");
            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Duration required");

        }
    }
}
