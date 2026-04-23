using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Track(string name) : BaseEntity<Guid> {
    public Name Name { get; private set; } = new(name);

    private readonly List<Race> _races = [];
    public IReadOnlyCollection<Race> Races => _races.AsReadOnly();

    public void ChangeName(string name) => Name = new(name);
}
