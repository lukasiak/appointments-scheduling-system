using App.Core.Application.Interfaces;
using App.Core.Domain.Entities;
using App.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        /// <summary>
        /// Gets all appointments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        /// <summary>
        /// Creates an appointment, should send back an specified appointment so we can handle it directly on client when creating
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task CreateAppointment(Appointment appointment)
        {
            appointment.StartTime = new DateTime(1, 1, 1, appointment.StartTime.Hour, appointment.StartTime.Minute, 0);
            appointment.EndTime = new DateTime(1, 1, 1, appointment.EndTime.Hour, appointment.EndTime.Minute, 0);

            if (await _appointmentRepository.CheckIfDateIsFree(appointment.Date, appointment.StartTime, appointment.EndTime))
            {
                await _appointmentRepository.InsertAsync(appointment);

                await _appointmentRepository.SaveAsync();

                return;
            }

            throw new ArgumentException("Time is already taken");
        }
    }
}
