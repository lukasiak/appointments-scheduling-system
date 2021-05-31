using App.Core.Domain.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Domain.Repositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<bool> CheckIfDateIsFree(DateTime date, DateTime startDate, DateTime endDate);
    }
}
