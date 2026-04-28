using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver> {
    public void Configure(EntityTypeBuilder<Driver> builder) {
        builder.ComplexProperty(x => x.FullName, x => {
            x.Property(x => x.FirstName).HasMaxLength(FullName.MaxNameLength);
            x.Property(x => x.LastName).HasMaxLength(FullName.MaxNameLength);
        });

        builder.Property(x => x.Number)
               .HasConversion(x => x.Value, x => new RacingNumber(x));

        builder.ToTable("Drivers", x => x.HasCheckConstraint("CK_Driver_Number", $"\"{nameof(Driver.Number)}\" > {RacingNumber.MinValue}"));
    }
}
