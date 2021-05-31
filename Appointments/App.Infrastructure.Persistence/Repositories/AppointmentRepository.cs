using App.Core.Domain.Entities;
using App.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentContext context)
            : base(context)
        {
        }

        public async Task<bool> CheckIfDateIsFree(DateTime date, DateTime startDate, DateTime endDate)
        {
            return !(await _context.Appointments.AnyAsync(a => 
                date.Date == a.Date.Date &&
                (startDate > a.StartTime && startDate < a.EndTime 
                || endDate > a.StartTime && endDate < a.EndTime)));
        }
    }
}
