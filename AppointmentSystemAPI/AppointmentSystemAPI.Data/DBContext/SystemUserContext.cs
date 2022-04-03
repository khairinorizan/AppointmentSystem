using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class SystemUserContext : DbContext
    {
        private readonly string _connectionString;
        
        public virtual DbSet<SystemUser> SystemUsers { get; set; }

        public SystemUserContext(string connectionString)
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
            modelBuilder.Entity<SystemUser>(eb =>
            {
                eb.HasKey(su => su.UserID);

                eb
                    .HasOne(su => su.Department)
                    .WithOne(d => d.SystemUser)
                    .HasForeignKey("DepartmentID");
            });
        }
    }
}