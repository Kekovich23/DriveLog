using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Driver : BaseEntity<Guid> {
    public Driver(string firstName, string lastName, int number) {
        FullName = new(firstName, lastName);
        Number = new(number);
    }

    protected Driver() { }

    public FullName FullName { get; private set; } = null!;
    public RacingNumber Number { get; private set; } = null!;

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();

    public void ChangeName(string firstName, string lastName) => FullName = new(firstName, lastName);
    public void ChangeNumber(int number) => Number = new(number);
}
