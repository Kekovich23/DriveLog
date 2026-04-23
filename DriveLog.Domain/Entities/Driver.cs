using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Driver(string firstName, string lastName, int number) : BaseEntity<Guid> {
    public FullName FullName { get; private set; } = new(firstName, lastName);
    public RacingNumber Number { get; private set; } = new(number);

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();

    public void ChangeName(string firstName, string lastName) => FullName = new(firstName, lastName);
    public void ChangeNumber(int number) => Number = new(number);
}
