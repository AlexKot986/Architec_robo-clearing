using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Contexts.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms").HasKey(rm => rm.Id);
        builder.Property(rm => rm.Id).HasColumnName("id");

        builder.Property(rm => rm.Name).HasMaxLength(20).HasColumnName("name");
    }
}