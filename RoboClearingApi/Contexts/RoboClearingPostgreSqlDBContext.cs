using Microsoft.EntityFrameworkCore;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Contexts
{
    public class RoboClearingPostgreSqlDBContext : DbContext
    {
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        private readonly IConfiguration _configuration;

        public RoboClearingPostgreSqlDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseNpgsql(_configuration.GetConnectionString("Database"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoboClearingPostgreSqlDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
