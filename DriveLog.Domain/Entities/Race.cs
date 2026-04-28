using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class Race(Track track, DateTimeOffset date) : BaseEntity<Guid> {
    public Guid TrackId { get; private set; } = track.Id;
    public DateTimeOffset Date { get; private set; } = date;
    public Track Track { get; private set; } = track;

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();
}
