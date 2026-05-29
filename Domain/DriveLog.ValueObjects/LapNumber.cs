namespace DriveLog.ValueObjects;

public record LapNumber {
    public LapNumber(int value) {
        if (value < 1) {
            throw new ArgumentOutOfRangeException(nameof(value), "Lap number must be greater than 0.");
        }

        Value = value;
    }

    public int Value { get; }
}
