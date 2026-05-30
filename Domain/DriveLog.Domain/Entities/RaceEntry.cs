using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class RaceEntry : BaseEntity<Guid> {
    public RaceEntry(Guid id, Driver driver, Car car, Race race) {
        Id = id;
        Driver = driver;
        Car = car;
        Race = race;
    }

    protected RaceEntry() { }

    public Driver Driver { get; private set; } = null!;
    public Car Car { get; private set; } = null!;
    public Race Race { get; private set; } = null!;
    private readonly List<RaceLap> _laps = [];
    public IReadOnlyCollection<RaceLap> Laps => _laps.AsReadOnly();

    public void AddLap(LapTime time) => _laps.Add(new RaceLap(new(_laps.Count + 1), this, time));
}
