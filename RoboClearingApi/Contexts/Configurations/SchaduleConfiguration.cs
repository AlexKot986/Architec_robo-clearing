using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Contexts.Configurations;

public class SchaduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("schedules").HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).HasColumnName("id");

        builder.HasOne(sc => sc.Room).WithMany();
        builder.Property(sc => sc.RoomId).HasColumnName("room_id");

        builder.HasOne(sc => sc.Robot).WithMany();
        builder.Property(sc => sc.RobotId).HasColumnName("robot_id");
                
        builder.Property(sc => sc.Type).HasMaxLength(20).HasColumnName("clearing_type");
             
        builder.Property(sc => sc.WeekDays).HasColumnName("week_days");

        builder.Property(sc => sc.Start).HasColumnName("start");
        builder.Property(sc => sc.End).HasColumnName("end");
    }
}