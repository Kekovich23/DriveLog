using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Driver : AggregateEntity<Guid> {
    public Driver(Guid id, DriverName name, DriverNumber number) {
        Id = id;
        Name = name;
        Number = number;
    }

    protected Driver() { }

    public DriverName Name { get; private set; } = null!;
    public DriverNumber Number { get; private set; } = null!;

    public void ChangeName(DriverName name) => Name = name;
    public void ChangeNumber(DriverNumber number) => Number = number;
}
