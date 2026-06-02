using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceEntryConfiguration : IEntityTypeConfiguration<RaceEntry> {
    public void Configure(EntityTypeBuilder<RaceEntry> builder) {
        builder.ToTable("race_entries");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasOne<Driver>()
               .WithMany()
               .HasForeignKey(x => x.DriverId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Car>()
               .WithMany()
               .HasForeignKey(x => x.CarId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Laps)
               .WithOne()
               .HasForeignKey("RaceEntryId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex("RaceId", "DriverId")
               .IsUnique()
               .HasDatabaseName("IX_unique_race_driver");

        builder.HasIndex("RaceId", "CarId")
               .IsUnique()
               .HasDatabaseName("IX_unique_race_car");
    }
}
