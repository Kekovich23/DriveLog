using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class TrackConfiguration : IEntityTypeConfiguration<Track> {
    public void Configure(EntityTypeBuilder<Track> builder) 
        => builder.Property(x => x.Name)
                  .HasConversion(x => x.Value, x => new ValueObjects.Name(x))
                  .HasMaxLength(ValueObjects.Name.MaxNameLength);
}
