using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class WorkAssignedMapping
    {
        public static void MapWorkAssigned(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkAssigned>(entity =>
            {
                entity.Property<int>("BookingID");
                entity.Property<int>("EngineerID");
                entity.Property<int>("StatusID");
                
                entity.HasKey(wa => wa.WorkID);
                
                entity
                    .HasOne(wa => wa.Booking)
                    .WithOne(b => b.WorkAssigned)
                    .HasForeignKey("BookingID");

                entity
                    .HasOne(wa => wa.Engineer)
                    .WithOne(e => e.WorkAssigned)
                    .HasForeignKey("EngineerID");

                entity
                    .HasOne(wa => wa.WorkStatus)
                    .WithOne(ws => ws.WorkAssigned)
                    .HasForeignKey("StatusID");

                entity
                    .Property(wa => wa.WorkID)
                    .HasColumnName("WorkID");
                
                entity
                    .Property(wa => wa.BookingID)
                    .HasColumnName("BookingID");
                
                entity
                    .Property(wa => wa.EngineerID)
                    .HasColumnName("EngineerID");
                
                entity
                    .Property(wa => wa.StatusID)
                    .HasColumnName("StatusID");

                entity.ToTable("WorkAssigned", "dbo");
            });
        }
    }
}