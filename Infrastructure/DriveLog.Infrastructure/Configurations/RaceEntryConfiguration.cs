using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceEntryConfiguration : IEntityTypeConfiguration<RaceEntry> {
    public void Configure(EntityTypeBuilder<RaceEntry> builder) {
        builder.ToTable("race_entries");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DriverId).IsRequired();
        builder.Property(x => x.CarId).IsRequired();

        builder.HasOne<Driver>()
               .WithMany()
               .HasForeignKey(x => x.DriverId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Car>()
               .WithMany()
               .HasForeignKey(x => x.CarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new {x.RaceId, x.DriverId})
               .IsUnique()
               .HasDatabaseName("IX_unique_race_driver");

        builder.HasIndex(x => new {x.RaceId, x.CarId})
               .IsUnique()
               .HasDatabaseName("IX_unique_race_car");

        builder.HasMany(x => x.Laps)
               .WithOne()
               .HasForeignKey(x => x.RaceEntryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
