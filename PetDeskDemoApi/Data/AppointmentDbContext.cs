using Microsoft.EntityFrameworkCore;
using PetDeskDemoApi.Models;

namespace PetDeskDemoApi.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }

        // potentially do ConfirmedAppointments as well if needed

    }
}
