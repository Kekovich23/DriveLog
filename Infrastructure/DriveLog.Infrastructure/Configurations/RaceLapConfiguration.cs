using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceLapConfiguration : IEntityTypeConfiguration<RaceLap> {
    public void Configure(EntityTypeBuilder<RaceLap> builder) {
        builder.ToTable("race_laps", x => x.HasCheckConstraint("CK_lap_number_positive", "\"Id\" > 0"));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .HasConversion(x => x.Value, x => new LapNumber(x))
               .ValueGeneratedNever();

        builder.Property(x => x.Time)
               .HasConversion(x => x.Duration, x => new LapTime(x))
               .IsRequired();

        builder.HasIndex("RaceEntryId", "Id")
               .IsUnique()
               .HasDatabaseName("PK_race_entry_lap_number");
    }
}
