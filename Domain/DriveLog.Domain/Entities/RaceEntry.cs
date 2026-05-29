using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class RaceEntry : BaseEntity<Guid> {
    public RaceEntry(Guid id, Guid driverId, Guid carId, Guid raceId) {
        Id = id;
        DriverId = driverId;
        CarId = carId;
        RaceId = raceId;
    }

    protected RaceEntry() { }

    public Guid DriverId { get; private set; }
    public Guid CarId { get; private set; }
    public Guid RaceId { get; private set; }
    private readonly List<RaceLap> _laps = [];
    public IReadOnlyCollection<RaceLap> Laps => _laps.AsReadOnly();

    public void AddLap(LapTime time) => _laps.Add(new RaceLap(new(_laps.Count + 1), Id, time));
}
