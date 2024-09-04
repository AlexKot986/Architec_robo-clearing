using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Contexts.Configurations;

public class RobotConfiguration : IEntityTypeConfiguration<Robot>
{
    public void Configure(EntityTypeBuilder<Robot> builder)
    {
        builder.ToTable("robots").HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("id");
                
        builder.Property(r => r.Status).HasColumnName("status");

        builder.Property(r => r.Model).HasColumnName("model").HasMaxLength(20);
        builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(20);
    }
}