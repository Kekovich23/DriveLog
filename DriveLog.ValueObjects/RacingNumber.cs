using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.ValueObjects;

public record RacingNumber {
    public int Value { get; init; }
    public RacingNumber(int number) {
        if (number < 0) {
            throw new NumberIsNegativeException(number);
        }

        Value = number;
    }
}
