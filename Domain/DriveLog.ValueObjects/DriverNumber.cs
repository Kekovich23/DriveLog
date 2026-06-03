namespace DriveLog.ValueObjects;

public record DriverNumber {
    public DriverNumber(int value) {
        if (value <= 0) {
            throw new ArgumentException("Driver number must be positive.");
        }

        Value = value;
    }

    public int Value { get; set; }
}
