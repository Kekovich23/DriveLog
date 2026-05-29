using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver> {
    public void Configure(EntityTypeBuilder<Driver> builder) {
        builder.ToTable("drivers", x => x.HasCheckConstraint("CK_driver_number_positive", "\"Number\" > 0"));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ComplexProperty(x => x.Name, builder => {
            builder.Property(x => x.FirstName)
                   .HasMaxLength(DriverName.MaxLength)
                   .IsRequired();
            builder.Property(x => x.LastName)
                   .HasMaxLength(DriverName.MaxLength)
                   .IsRequired();
        });

        builder.Property(x => x.Number)
               .HasConversion(x => x.Value, x => new DriverNumber(x))
               .IsRequired();
    }
}
