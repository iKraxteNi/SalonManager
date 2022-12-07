using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Interfaces
{
    public interface IAppointmentService
    {
        void DelateAppointment(long Id);
        void EditAppointment(AppointmentDto model);
        List<AppointmentDto> GetAllAppointments(AppointmentGetDTO query);
    }
}