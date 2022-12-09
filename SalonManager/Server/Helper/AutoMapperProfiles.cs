using AutoMapper;
using SalonManager.Entities;

using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Helper
  
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Customer, CustomerGetDTO>();
            CreateMap<CustomerEditDTO, Customer>();
        }

    }
}
