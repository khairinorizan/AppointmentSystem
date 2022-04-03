using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class DepartmentContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<Department> Departments { get; set; }

        public DepartmentContext(string connectionString)
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
            modelBuilder.Entity<Department>(eb =>
            {
                eb.HasKey(dept => dept.DepartmentID);

                eb
                    .Property(e => e.DepartmentID)
                    .HasColumnName("DepartmentID");

                eb
                    .Property(e => e.DepartmentName)
                    .HasColumnName("DepartmentName");

                eb
                    .Property(e => e.DepartmentFloor)
                    .HasColumnName("DepartmentFloor");
            });
        }
    }   
}