using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Entities;

public class Race(Track track, DateTime date) : BaseEntity<Guid> {
    public Guid TrackId { get; private set; } = track.Id;
    public DateTime Date { get; private set; } = date;
    public Track Track { get; private set; } = track;

    private readonly List<RaceLap> _raceLaps = [];
    public IReadOnlyCollection<RaceLap> RaceLaps => _raceLaps.AsReadOnly();
}
