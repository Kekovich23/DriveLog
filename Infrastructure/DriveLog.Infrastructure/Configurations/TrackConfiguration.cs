using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class TrackConfiguration : IEntityTypeConfiguration<Track> {
    public void Configure(EntityTypeBuilder<Track> builder) {
        builder.ToTable("tracks");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Name)
               .HasConversion(x => x.Value, x => new TrackName(x))
               .HasMaxLength(TrackName.MaxLength)
               .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
