using App.Infrastructure.Persistence;

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
