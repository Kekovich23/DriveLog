namespace DriveLog.ValueObjects.Exceptions;

public class StringLengthExceedsLimit(int value, string paramName)
    : ArgumentException($"The \"{paramName}\" parameter must not exceed {value} characters in length.");
