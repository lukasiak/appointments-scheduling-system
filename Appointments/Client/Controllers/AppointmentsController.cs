using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Application.Dto;
using App.Core.Application.Interfaces;
using App.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentDto>> Get()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public async Task CreateAppointment(AppointmentDto appointment)
        {
            try
            {
                var newAppointment = _mapper.Map<Appointment>(appointment);
                await _appointmentService.CreateAppointment(newAppointment);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Should throw an nice error", ex);
            }
        }
    }
}
