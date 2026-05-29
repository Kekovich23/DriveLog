using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.ValueObjects;

public record RacingNumber {
    public const int MinValue = 0;
    public int Value { get; init; }
    public RacingNumber(int number) {
        if (number < MinValue) {
            throw new NumberIsNegativeException(number);
        }

        Value = number;
    }

    protected RacingNumber() { }
}
