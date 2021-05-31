using App.Core.Application.Interfaces;
using App.Core.Application.Services;
using App.Core.Domain.Repositories;
using App.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.IoC
{
    /// <summary>
    /// Container class for register dependencies
    /// </summary>
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //domain
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            //application
            services.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
