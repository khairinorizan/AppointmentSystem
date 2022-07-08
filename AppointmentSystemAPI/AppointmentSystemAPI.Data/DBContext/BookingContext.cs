using System;
namespace AppointmentSystemAPI.Data.DBContext
{
    using Microsoft.EntityFrameworkCore;
    using AppointmentSystemAPI.Data.Model;

    public class BookingContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<Booking> Bookings { get; set; }

        public BookingContext(string connectionString)
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
            modelBuilder.Entity<Booking>(eb =>
            {
                eb.HasKey(b => b.BookingID);

                eb
                    .HasOne(booking => booking.SystemUser)
                    .WithOne(su => su.Booking)
                    .HasForeignKey("UserID");

                eb
                    .HasOne(booking => booking.Device)
                    .WithOne(device => device.Booking)
                    .HasForeignKey("DeviceID");

                eb
                    .HasOne(booking => booking.Problem)
                    .WithOne(problem => problem.Booking)
                    .HasForeignKey("ProblemID");
            });
        }
    }
}
