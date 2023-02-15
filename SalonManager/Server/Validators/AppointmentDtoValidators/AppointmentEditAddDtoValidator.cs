using FluentValidation;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Validators.AppointmentDtoValidators
{
    public class AppointmentEditAddDtoValidator : AbstractValidator<AppointmentDto>
    {
        public AppointmentEditAddDtoValidator()
        {

            RuleFor(x => x.Start)
                .NotEmpty().WithMessage("Start is required");
            RuleFor(x => x.End)
                .NotEmpty().WithMessage("End is required");
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required");
            RuleFor(x => x.ServiceId)
                .NotEmpty().WithMessage("ServiceId is required");



        }

    }


}
