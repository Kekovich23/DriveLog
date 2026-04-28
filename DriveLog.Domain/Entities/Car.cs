using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Car : BaseEntity<Guid> {
    public Car(int number) => Number = new(number);
    protected Car() { }

    public RacingNumber Number { get; private set; } = null!;

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();

    public void ChangeNumber(int number) => Number = new(number);
}
