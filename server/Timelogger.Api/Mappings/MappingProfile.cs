using AutoMapper;
using Timelogger.Api.DTOs;
using Timelogger.Data.Models;

namespace FreelancerTimeTracking.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)); // Assuming Project entity has a Customer navigation property
            CreateMap<ProjectDTO, Project>();

            CreateMap<TimeRegistration, TimeRegistrationDTO>().ReverseMap();
        }
    }
}