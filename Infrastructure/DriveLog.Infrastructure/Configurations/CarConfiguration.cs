using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveLog.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car> {
    public void Configure(EntityTypeBuilder<Car> builder) {
        builder.ToTable("cars", x => x.HasCheckConstraint("CK_car_number_positive", "\"Number\" > 0"));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Number)
               .HasConversion(x => x.Value, x => new CarNumber(x))
               .IsRequired();

        builder.HasIndex(x => x.Number).IsUnique();
    }
}
