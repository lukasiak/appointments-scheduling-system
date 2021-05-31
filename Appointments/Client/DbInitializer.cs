using App.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public static class DbInitializer
    {
        public static void Initialize(AppointmentContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
