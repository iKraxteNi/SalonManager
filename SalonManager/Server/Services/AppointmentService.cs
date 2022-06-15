
using SalonManager.Server.Data;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Services
{
    public class AppointmentService
    {
        public ApplicationDbContext _dbContext;

        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AppointmentDto> GetAllAppointments(AppointmentGetDTO query)
        {
            //var queryable = _dbContext.Users.AsNoTracking();
            //queryable = ApplyGetAllFilter(query, queryable);

            //var employees = queryable.ToList();
            //employees.ForEach(u => u.Role = GetUserRole(u));

            var AllAppointmentsNoflitr = _dbContext.Appointments.Select(x => new AppointmentDto()
            {
                Id = x.Id,
                EndTime = x.EndTime,
                StartTime = x.StartTime,
                Note = x.Note

            }).ToList();

           // var AllAppointments = AllAppointmentsNoflitr.Where(x => x.StartTime.Date <=end && start <= x.EndTime.Date);

            return new List<AppointmentDto>(AllAppointmentsNoflitr);
        }
        //public List<AppointmentDto> GetAllAppointments(DateTime start, DateTime end)
        //{
        //    var AllAppointments = _dbContext.Appointments.Select(x => new AppointmentDto()
        //    {
        //        Id = x.Id,
        //        EndTime = x.EndTime,
        //        StartTime = x.StartTime,
        //        Note = x.Note

        //    }).ToList();
        //    return AllAppointments.Where(x => x.StartTime.Date <= end && start <= x.EndTime.Date);
        //}


    }
}
