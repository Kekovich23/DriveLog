namespace DriveLog.ValueObjects;

public record LapTime {
    public LapTime(TimeSpan value) {
        if (value <= TimeSpan.Zero) {
            throw new ArgumentOutOfRangeException(nameof(value), "Lap time must be positive.");
        }

        Duration = value;
    }

    public TimeSpan Duration { get; init; }
}
