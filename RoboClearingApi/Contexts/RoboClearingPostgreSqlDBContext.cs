using Microsoft.EntityFrameworkCore;
using RoboClearingApi.Models.Domain;
using System.Reflection.Emit;

namespace RoboClearingApi.Contexts
{
    public class RoboClearingPostgreSqlDBContext : DbContext
    {
        public DbSet<Robot> Robots { get; set; }
        public DbSet<RoboStatus> RoboStatuses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TypeOfClearing> Types { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }

        private readonly string _connectionString;

        public RoboClearingPostgreSqlDBContext()
        {
            _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=example;Database=RoboClearingDb";
        }
        public RoboClearingPostgreSqlDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>(entity =>
            {
                entity.HasKey(r => r.Id).HasName("robot_pkey");
                entity.ToTable("robots");
                entity.Property(r => r.Id).HasColumnName("id");

                entity.HasOne(r => r.Status).WithMany(rs => rs.Robots);
                entity.Property(r => r.StatusId).HasColumnName("status_id");

                entity.Property(r => r.Model).HasColumnName("model").HasMaxLength(20);
                entity.Property(r => r.Name).HasColumnName("name").HasMaxLength(20);
                
            });

            modelBuilder.Entity<RoboStatus>(entity =>
            {
                entity.HasKey(rs => rs.Id).HasName("robostatus_pkey");
                entity.ToTable("robostatuses");
                entity.Property(rs => rs.Id).HasColumnName("id");

                entity.HasIndex(rs => rs.Title).IsUnique();
                entity.Property(r => r.Title).HasMaxLength(20).HasColumnName("title");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(rm => rm.Id).HasName("room_pkey");
                entity.ToTable("rooms");
                entity.Property(rm => rm.Id).HasColumnName("id");

                entity.Property(rm => rm.Name).HasMaxLength(20).HasColumnName("name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(sc => sc.Id).HasName("schadule_pkey");
                entity.ToTable("schedules");
                entity.Property(sc => sc.Id).HasColumnName("id");

                entity.HasOne(sc => sc.TypeOfClearing);
                entity.Property(sc => sc.TypeOfClearingId).HasMaxLength(20).HasColumnName("clearing_id");

                entity.HasMany(sc => sc.WeekDayList);
                entity.Property(sc => sc.WeekDaysId).HasColumnName("week_day_id");

                entity.Property(sc => sc.StartClearing).HasColumnName("start_clearing");
                entity.Property(sc => sc.EndClearing).HasColumnName("end_clearing");
            });

            modelBuilder.Entity<TypeOfClearing>(entity =>
            {
                entity.HasKey(tc => tc.Id).HasName("type_pkey");
                entity.ToTable("types");
                entity.Property(tc => tc.Id).HasColumnName("id");

                entity.HasIndex(tc => tc.Title).IsUnique();
                entity.Property(tc => tc.Title).HasMaxLength(20).HasColumnName("title");
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.HasKey(wk => wk.Id).HasName("week_day_pkey");
                entity.ToTable("week_days");
                entity.Property(wk => wk.Id).HasColumnName("id");

                entity.HasIndex(wk => wk.Day).IsUnique();
                entity.Property(wk => wk.Day).HasMaxLength(20).HasColumnName("day");
            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
