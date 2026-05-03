using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car> {
    public void Configure(EntityTypeBuilder<Car> builder) {
        builder.ComplexProperty(x => x.Number);

        builder.ToTable("Cars", x => x.HasCheckConstraint("CK_Car_Number", $"\"{nameof(Car.Number)}\" > {RacingNumber.MinValue}"));
    }
}
