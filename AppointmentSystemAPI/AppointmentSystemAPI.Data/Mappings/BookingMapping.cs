using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class BookingMapping
    {
        public static void MapBooking(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property<int>("UserID");
                entity.Property<int>("DeviceID");
                entity.Property<int>("ProblemID");
                
                entity.HasKey(booking => booking.BookingID);

                entity
                    .HasOne(booking => booking.SystemUser)
                    .WithOne(su => su.Booking)
                    .HasForeignKey("UserID");

                entity
                    .HasOne(booking => booking.Device)
                    .WithOne(device => device.Booking)
                    .HasForeignKey("DeviceID");

                entity
                    .HasOne(booking => booking.Problem)
                    .WithOne(problem => problem.Booking)
                    .HasForeignKey("ProblemID");

                entity
                    .Property(b => b.BookingID)
                    .HasColumnName("BookingID");

                entity
                    .Property(b => b.UserID)
                    .HasColumnName("UserID");

                entity
                    .Property(b => b.BookingDate)
                    .HasColumnName("BookingDate");

                entity
                    .Property(b => b.DeviceID)
                    .HasColumnName("DeviceID");

                entity
                    .Property(b => b.ProblemID)
                    .HasColumnName("ProblemID");

                entity
                    .Property(b => b.Description)
                    .HasColumnName("Description");

                entity.ToTable("Booking", "dbo");
            });
        }
    }
}