using AutoMapper;
using SalonManager.Entities;

using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Helper
  
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap()
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Start));
            CreateMap<AppointmentDto,Appointment >().ReverseMap()
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.StartTime)).ReverseMap();


            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(dest => dest.FullNameCastomer, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)); 

            CreateMap<CustomerEditDTO, Customer>();
            CreateMap<Service, ServiceGetAllDTO>().ReverseMap();
        }

    }
}
