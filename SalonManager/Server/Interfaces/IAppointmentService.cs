using SalonManager.Entities;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Interfaces
{
    public interface IAppointmentService
    {
        void DelateAppointment(long Id);
        void EditAppointment(Appointment model);
        IEnumerable<Appointment> GetAllAppointments();
    }
}