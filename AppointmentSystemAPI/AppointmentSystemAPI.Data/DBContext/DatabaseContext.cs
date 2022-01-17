using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Engineer> Engineers { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<WorkAssigned> WorkAssigns { get; set; }
        public virtual DbSet<WorkStatus> WorkStatus { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}