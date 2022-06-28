
using SalonManager.Entities;
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
            

           var AllAppointmentsNoflitr = _dbContext.Appointments.Where(p => p.IsDeleted == false).Select(x => new AppointmentDto()
            {
                Id = x.Id,
                End = x.EndTime,
                Start = x.StartTime,
                FullNameCastomer = x.FullNameCastomer,
                Note = x.Note

            }).ToList();

           // var AllAppointments = AllAppointmentsNoflitr.Where(x => x.StartTime.Date <=end && start <= x.EndTime.Date);

            return new List<AppointmentDto>(AllAppointmentsNoflitr);
        }

        public void EditAppointment(AppointmentDto model)
        {

            if (model.Id == 0)
            {
                var customerName = _dbContext.Customers.Where(p => p.Id == model.CustomerId).FirstOrDefault();

                var NewAppointment= new Appointment
                {
                    StartTime = model.Start,
                    EndTime = model.End,
                    CustomerId = model.CustomerId,
                    ServiceId = model.ServiceId,
                    Note = model.Note,
                    FullNameCastomer = customerName.FirstName + " "+ customerName.LastName,
                    


                };

                _dbContext.Appointments.Add(NewAppointment);
            }
            else
            {
                var appToUpdate = _dbContext.Appointments.Where(p => p.Id == model.Id).FirstOrDefault();
                _dbContext.Entry(appToUpdate).CurrentValues.SetValues(model);
            }
            _dbContext.SaveChanges();

        }
        public void DelateAppointment(long Id)
        {

            var delete = _dbContext.Appointments.Where(x => x.Id == Id).FirstOrDefault();

            _dbContext.Entry(delete).CurrentValues.SetValues(delete.IsDeleted = true);
            _dbContext.SaveChanges();

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
