using AutoMapper;
using SalonManager.Entities;

using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Helper
  
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppointmentDto,Appointment >()
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Start)).ReverseMap();

            CreateMap<AppointmentDto, AppointmentEditDto>()
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Start)).ReverseMap();


            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(dest => dest.FullNameCastomer, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)); 

            CreateMap<CustomerEditDTO, Customer>();
            CreateMap<Service, ServiceGetAllDTO>().ReverseMap();
        }

    }
}
