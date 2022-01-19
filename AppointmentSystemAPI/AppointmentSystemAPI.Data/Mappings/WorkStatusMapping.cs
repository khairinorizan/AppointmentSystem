using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class WorkStatusMapping
    {
        public static void MapWorkStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkStatus>(entity =>
            {
                entity.HasKey(ws => ws.WorkStatusID);
                
                entity
                    .Property(ws => ws.StatusType)
                    .HasColumnName("StatusType");
                
                entity.ToTable("WorkStatus", "dbo");
            });
        }
    }
}