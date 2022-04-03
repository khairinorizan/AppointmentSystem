using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class EngineerContext : DbContext
    {
        private readonly string _connectionString;
        
        public virtual DbSet<Engineer> Engineers { get; set; }

        public EngineerContext(string connectionString)
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
            modelBuilder.Entity<Engineer>(eb =>
            {
                eb.HasKey(engineer => engineer.EngineerID);
            });
        }
    }
}