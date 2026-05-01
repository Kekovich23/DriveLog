using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Track : BaseEntity<Guid> {
    public Track(string name) => Name = new(name);

    protected Track() { }

    public Name Name { get; private set; } = null!;

    private readonly List<Race> _races = [];
    public IReadOnlyCollection<Race> Races => _races.AsReadOnly();

    public void ChangeName(string name) => Name = new(name);

    public Race CreateRace(DateTimeOffset date) {
        var race = new Race(Id, date);

        _races.Add(race);

        return race;
    }
}
