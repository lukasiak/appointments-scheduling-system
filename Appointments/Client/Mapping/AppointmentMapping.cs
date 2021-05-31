using App.Core.Application.Dto;
using App.Core.Domain.Entities;
using AutoMapper;

namespace App.Mapping
{
    public class AppointmentMapping : Profile
    {
        public AppointmentMapping()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
