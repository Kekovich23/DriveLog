namespace DriveLog.ValueObjects;

public record CarNumber {
    public CarNumber(int value) {
        if (value <= 0) {
            throw new ArgumentException("Car number must be positive.");
        }

        Value = value;
    }

    public int Value { get; set; }
}
