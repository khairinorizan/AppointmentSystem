using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class SystemUserMapping
    {
        public static void MapSystemUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.Property<int>("DepartmentID");

                entity.HasKey(su => su.UserID);

                entity
                    .HasOne(su => su.Department)
                    .WithOne(d => d.SystemUser)
                    .HasForeignKey("DepartmentID");

                entity
                    .Property(su => su.UserID)
                    .HasColumnName("UserID");

                entity
                    .Property(su => su.FirstName)
                    .HasColumnName("FirstName");

                entity
                    .Property(su => su.LastName)
                    .HasColumnName("LastName");

                entity
                    .Property(su => su.EmployeeID)
                    .HasColumnName("EmployeeID");

                entity
                    .Property(su => su.EmailAddress)
                    .HasColumnName("EmailAddress");

                entity
                    .Property(su => su.DOB)
                    .HasColumnName("DOB");

                entity
                    .Property(su => su.DepartmentID)
                    .HasColumnName("DepartmentID");

                entity.ToTable("SystemUser", "dbo");
            });
        }
    }
}