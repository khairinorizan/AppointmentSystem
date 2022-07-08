namespace AppointmentSystemAPI.Data.DBContext
{
    using AppointmentSystemAPI.Data.Model;
    using Microsoft.EntityFrameworkCore;

    public class WorkStatusContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<WorkStatus> WorkStatus { get; set; }

        public WorkStatusContext(string connectionString)
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
            modelBuilder.Entity<WorkStatus>(eb =>
            {
                eb.HasKey(ws => ws.WorkStatusID);
            });
        }
    }
}
