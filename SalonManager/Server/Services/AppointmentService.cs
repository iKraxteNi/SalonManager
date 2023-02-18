using AutoMapper;
using SalonManager.Entities;
using SalonManager.Server.Data;
using SalonManager.Server.Interfaces;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Services
{
    public class AppointmentService : IAppointmentService
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<Appointment> GetAllAppointments()
        {

            //var AllAppointmentsNoflitr = _dbContext.Appointments.Where(p => p.IsDeleted == false).Select(x => new AppointmentDto()
            //{
            //    Id = x.Id,
            //    End = x.EndTime,
            //    Start = x.StartTime,
            //    FullNameCastomer = x.FullNameCastomer,
            //    Note = x.Note

            //}).ToList();

            // return new List<AppointmentDto>(AllAppointmentsNoflitr);

            //used AutoMapper


            return (_dbContext.Appointments.Where(p => p.IsDeleted == false));//.Select(p => _mapper.Map<AppointmentDto>(p)).ToList());
        }

        public void EditAppointment(Appointment model)
        {

            if (model.Id == 0)
            {
                var customerName = _dbContext.Customers.Where(p => p.Id == model.CustomerId).FirstOrDefault();
                var serviceName = _dbContext.Servicess.Where(p => p.Id == model.ServiceId).FirstOrDefault();
                var NewAppointment = new Appointment
                {
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    CustomerId = model.CustomerId,
                    ServiceId = model.ServiceId,
                    ServiceName = serviceName.Name,
                    Note = model.Note,
                    FullNameCastomer = customerName.FirstName + " " + customerName.LastName,

                };

                _dbContext.Appointments.Add(NewAppointment);
            }
            else
            {
                var appToUpdate = _dbContext.Appointments.Where(p => p.Id == model.Id).FirstOrDefault();
                var serviceName = _dbContext.Servicess.Where(p => p.Id == model.ServiceId).FirstOrDefault();

                appToUpdate.Note = model.Note;
                appToUpdate.EndTime = model.EndTime;
                appToUpdate.StartTime = model.StartTime;
                appToUpdate.CustomerId = model.CustomerId;
                appToUpdate.ServiceId = model.ServiceId;
                appToUpdate.ServiceName = serviceName.Name;
                appToUpdate.FullNameCastomer = model.FullNameCastomer;

                // _dbContext.Entry(appToUpdate).CurrentValues.SetValues(model);
            }
            _dbContext.SaveChanges();

        }
        public void DelateAppointment(long Id)
        {

            var delete = _dbContext.Appointments.Where(x => x.Id == Id).FirstOrDefault();

            _dbContext.Entry(delete).CurrentValues.SetValues(delete.IsDeleted = true);
            _dbContext.SaveChanges();

        }

        //public List<AppointmentDto> GetAppointmentsByTimeRange(DateTime start, DateTime end)
        //{
        //    var AllAppointments = _dbContext.Appointments.Where(p => p.IsDeleted == false))


        //  //  var AllAppointments = _dbContext.Appointments.Select(x => new AppointmentDto()
        //    {
        //        Id = x.Id,
        //        EndTime = x.EndTime,
        //        StartTime = x.StartTime,
        //        Note = x.Note

        //    }).ToList();
        //    return AllAppointments.Where(x => x.StartTime.Date <= end && start <= x.EndTime.Date);
        //}

        //public IEnumerator<AppointmentDto> GetAppointmentsByTimeRange(DateTime Start, DateTime End)
        //{
        //    var allAppointments = _dbContext.Appointments
        //        .Where(a => a.IsDeleted == false && a.StartTime >= Start && a.EndTime <= End)
        //        .ToList();

        //    var appointmentDtos = _mapper.Map<IEnumerator<AppointmentDto>>(allAppointments);

        //    return appointmentDtos;
        //}


        public IEnumerable<AppointmentDto> GetAppointmentsByTimeRange(DateTime start, DateTime end)
        {
            var AllAppointments = _dbContext.Appointments
                .Where(p => p.IsDeleted == false)
                .Select(x => new AppointmentDto()
                {
                    Note = x.Note,
                    End = x.EndTime,
                    Start = x.StartTime,
                    CustomerId = x.CustomerId,
                    ServiceId = x.ServiceId,
                    ServiceName = x.ServiceName,
                    FullNameCastomer = x.FullNameCastomer

                }).ToList();

            return AllAppointments.Where(x => x.Start.Date <= end && start <= x.End.Date);
        }





    }
}
