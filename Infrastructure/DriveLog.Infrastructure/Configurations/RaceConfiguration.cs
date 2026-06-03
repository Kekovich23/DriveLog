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

        builder.HasOne<Track>()
               .WithMany()
               .HasForeignKey(x => x.TrackId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Entries)
               .WithOne()
               .HasForeignKey("RaceId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
