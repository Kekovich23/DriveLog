using DriveLog.Domain.Entities.Base;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Entities;

public class RaceLap : BaseEntity<LapNumber> {
    public RaceLap(LapNumber lapNumber, LapTime time) {
        Id = lapNumber;
        Time = time;
    }

    protected RaceLap() { }

    public LapTime Time { get; set; } = null!;
}
