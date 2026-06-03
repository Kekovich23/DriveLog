using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class Track : AggregateEntity<Guid> {
    public Track(Guid id, TrackName name) : base(id) => Name = name;

    protected Track() { }

    public TrackName Name { get; private set; } = null!;

    public void ChangeName(TrackName name) => Name = name;
}
