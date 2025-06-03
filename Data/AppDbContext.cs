using Microsoft.EntityFrameworkCore;
using volunteer_app_backend.Models;

namespace volunteer_app_backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VolunteerDB");
        }
    }
}
