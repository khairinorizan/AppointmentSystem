using Microsoft.EntityFrameworkCore;
using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class DeviceMapping
    {
        public static void MapDevice(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(device => device.DeviceID);

                entity
                    .Property(device => device.DeviceID)
                    .HasColumnName("DeviceID");

                entity
                    .Property(device => device.DeviceType)
                    .HasColumnName("DeviceType");

                entity.ToTable("Device", "dbo");
            });
        }
    }
}