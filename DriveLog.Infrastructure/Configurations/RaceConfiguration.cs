using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceConfiguration : IEntityTypeConfiguration<Race> {
    public void Configure(EntityTypeBuilder<Race> builder) 
        => builder.HasOne(x => x.Track)
                  .WithMany(x => x.Races)
                  .OnDelete(DeleteBehavior.Restrict);
}
