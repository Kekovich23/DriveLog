using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Car : AggregateEntity<Guid> {
    public Car(Guid id, CarNumber number) {
        Id = id;
        Number = number;
    }

    protected Car() { }

    public CarNumber Number { get; private set; } = null!;

    public void ChangeNumber(CarNumber number) => Number = number;
}
