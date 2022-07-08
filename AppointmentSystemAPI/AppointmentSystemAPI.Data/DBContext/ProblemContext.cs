namespace AppointmentSystemAPI.Data.DBContext
{
    using AppointmentSystemAPI.Data.Model;
    using Microsoft.EntityFrameworkCore;

    public class ProblemContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<Problem> Problems { get; set; }

        public ProblemContext(string connectionString)
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
            modelBuilder.Entity<Problem>(eb =>
            {
                eb.HasKey(problem => problem.ProblemID);
            });
        }
    }
}
