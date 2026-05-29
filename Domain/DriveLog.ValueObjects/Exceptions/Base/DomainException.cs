namespace DriveLog.ValueObjects.Exceptions.Base;

public abstract class DomainException(string message) : Exception(message);
