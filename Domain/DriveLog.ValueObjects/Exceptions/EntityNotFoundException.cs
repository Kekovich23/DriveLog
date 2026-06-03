namespace DriveLog.ValueObjects.Exceptions;

public class EntityNotFoundException(string message) : KeyNotFoundException(message);
