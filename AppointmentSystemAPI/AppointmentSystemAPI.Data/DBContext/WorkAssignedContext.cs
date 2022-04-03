using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.DBContext
{
    public class WorkAssignedContext : DbContext
    {
        private readonly string _connectionString;

        public WorkAssignedContext(string connectionString)
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
            modelBuilder.Entity<WorkAssigned>(eb =>
            {
                eb.HasKey(wa => wa.WorkID);

                eb
                    .HasOne(wa => wa.Booking)
                    .WithOne(b => b.WorkAssigned)
                    .HasForeignKey("BookingID");

                eb
                    .HasOne(wa => wa.Engineer)
                    .WithOne(e => e.WorkAssigned)
                    .HasForeignKey("EngineerID");

                eb
                    .HasOne(wa => wa.WorkStatus)
                    .WithOne(ws => ws.WorkAssigned)
                    .HasForeignKey("StatusID");
            });
        }
    }   
}