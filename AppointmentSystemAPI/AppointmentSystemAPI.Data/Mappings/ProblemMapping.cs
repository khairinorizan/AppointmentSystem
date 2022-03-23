using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class ProblemMapping
    {
        public static void MapProblem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>(entity =>
            {
                entity.HasKey(problem => problem.ProblemID);

                entity
                    .Property(problem => problem.ProblemID)
                    .HasColumnName("ProblemID");
                
                entity
                    .Property(problem => problem.ProblemType)
                    .HasColumnName("ProblemType");
                
                entity.ToTable("Problem", "dbo");
            });
        }
    }
}