namespace DriveLog.ValueObjects;

public record RaceDate {
    public RaceDate(DateTimeOffset value) => Value = value;

    public DateTimeOffset Value { get; }
}
