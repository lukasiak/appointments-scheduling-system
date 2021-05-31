using App.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task CreateAppointment(Appointment appointment);
    }
}
