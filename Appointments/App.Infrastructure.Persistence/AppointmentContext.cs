using App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
        }
    }
}
