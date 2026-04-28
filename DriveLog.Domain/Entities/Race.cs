using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class Race : BaseEntity<Guid> {
    public Race(Track track, DateTimeOffset date) {
        TrackId = track.Id;
        Date = date;
        Track = track;
    }

    protected Race() { }

    public Guid TrackId { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public Track Track { get; private set; } = null!;

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();
}
