using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.AppointmentDtoValidators
{
    public class AppointmentDeleteDtoValidator : AbstractValidator<AppointmentDto>
    {
        public AppointmentDeleteDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("AppointmentId is required");
        }

    }
}
