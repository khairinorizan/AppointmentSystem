using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class EngineerMapping
    {
        public static void MapEngineer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engineer>(entity =>
            {
                entity.HasKey(engineer => engineer.EngineerID);
                
                entity
                    .Property(engineer => engineer.EngineerID)
                    .HasColumnName("EngineerID");
                
                entity
                    .Property(engineer => engineer.FirstName)
                    .HasColumnName("FirstName");

                entity
                    .Property(engineer => engineer.LastName)
                    .HasColumnName("LastName");

                entity
                    .Property(engineer => engineer.EmployeeID)
                    .HasColumnName("EmployeeID");

                entity
                    .Property(engineer => engineer.EmailAddress)
                    .HasColumnName("EmailAddress");

                entity
                    .Property(engineer => engineer.DOB)
                    .HasColumnName("DOB");

                entity.ToTable("Engineer", "dbo");
            });
        }
    }
}