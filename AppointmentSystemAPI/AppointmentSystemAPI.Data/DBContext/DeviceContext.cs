using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class DeviceContext : DbContext
    {
        private readonly string _connectionString;
        
        public virtual DbSet<Device> Devices { get; set; }

        public DeviceContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(eb =>
            {
                eb.HasKey(device => device.DeviceID);
            });
        }
    }   
}