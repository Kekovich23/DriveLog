using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class RaceLapConfiguration : IEntityTypeConfiguration<RaceLap> {
    public void Configure(EntityTypeBuilder<RaceLap> builder) {
        builder.HasOne(x => x.Car).WithMany(x => x.RaceLaps).OnDelete(DeleteBehavior.Restrict);
        builder.Metadata.FindNavigation(nameof(Car.RaceLaps))?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(x => x.Driver).WithMany(x => x.RaceLaps).OnDelete(DeleteBehavior.Restrict);
        builder.Metadata.FindNavigation(nameof(Driver.RaceLaps))?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(x => x.Race).WithMany(x => x.RaceLaps).OnDelete(DeleteBehavior.Cascade);
        builder.Metadata.FindNavigation(nameof(Race.RaceLaps))?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
