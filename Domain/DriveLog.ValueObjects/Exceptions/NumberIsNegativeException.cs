namespace DriveLog.ValueObjects.Exceptions;

public class NumberIsNegativeException(int number)
    : ArgumentException($"Racing number cannot be negative. Received: {number}.");
