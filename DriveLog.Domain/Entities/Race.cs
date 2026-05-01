using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class Race : BaseEntity<Guid> {
    public Race(Guid trackId, DateTimeOffset date) {
        TrackId = trackId;
        Date = date;
    }

    protected Race() { }

    public Guid TrackId { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public Track? Track { get; private set; }

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();

    public RaceLap CreateRaceLap(Guid driverId, Guid carId, int lapNumber, TimeSpan lapTime) {
        var raceLap = new RaceLap(Id, driverId, carId, lapNumber, lapTime);

        _raceLaps.Add(raceLap);

        return raceLap;
    }

    public void ChangeDate(DateTimeOffset date) => Date = date;
}
