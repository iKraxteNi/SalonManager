using SalonManager.Entities;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Interfaces
{
    public interface IAppointmentService
    {
        void DelateAppointment(long Id);
        void EditAppointment(Appointment model);
        List<AppointmentDto> GetAllAppointments(AppointmentGetDTO query);
    }
}