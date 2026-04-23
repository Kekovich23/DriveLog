using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Car(int number) : BaseEntity<Guid> {
    public RacingNumber Number { get; private set; } = new(number);

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();

    public void ChangeNumber(int number) => Number = new(number);
}
