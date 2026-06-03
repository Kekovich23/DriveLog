namespace DriveLog.ValueObjects.Exceptions;

public class ValidatorNullException(string message) : NullReferenceException(message);