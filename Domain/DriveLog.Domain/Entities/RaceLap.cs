using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class RaceLap : BaseEntity<LapNumber> {
    public RaceLap(LapNumber lapNumber, RaceEntry raceEntry, LapTime time) {
        Id = lapNumber;
        Time = time;
        RaceEntry = raceEntry;
    }

    protected RaceLap() { }

    public LapTime Time { get; private set; } = null!;
    public RaceEntry RaceEntry { get; private set; } = null!;
}
