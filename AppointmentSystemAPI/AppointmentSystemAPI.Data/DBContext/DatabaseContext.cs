using AppointmentSystemAPI.Data.Mappings;
using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapBooking();
            modelBuilder.MapDepartment();
            modelBuilder.MapDevice();
            modelBuilder.MapEngineer();
            modelBuilder.MapProblem();
            modelBuilder.MapSystemUser();
            modelBuilder.MapWorkAssigned();
            modelBuilder.MapWorkStatus();
        }
    }
}