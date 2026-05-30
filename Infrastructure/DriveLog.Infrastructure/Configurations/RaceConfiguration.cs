using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceConfiguration : IEntityTypeConfiguration<Race> {
    public void Configure(EntityTypeBuilder<Race> builder) {
        builder.ToTable("races");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Date)
               .HasConversion(x => x.Value, x => new RaceDate(x))
               .IsRequired();

        builder.HasOne(x => x.Track)
               .WithMany()
               .HasForeignKey("TrackId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Entries)
               .WithOne(x => x.Race)
               .HasForeignKey("RaceId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
