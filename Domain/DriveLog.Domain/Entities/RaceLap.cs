using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class RaceLap : BaseEntity<LapNumber> {
    public RaceLap(LapNumber lapNumber, Guid raceEntryId, LapTime time) {
        Id = lapNumber;
        Time = time;
        RaceEntryId = raceEntryId;
    }

    protected RaceLap() { }

    public LapTime Time { get; set; } = null!;
    public Guid RaceEntryId { get; set; }
}
