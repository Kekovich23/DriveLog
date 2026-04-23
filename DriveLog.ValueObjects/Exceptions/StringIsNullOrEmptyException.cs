namespace DriveLog.ValueObjects.Exceptions;

public class StringIsNullOrEmptyException(string paramName)
    : ArgumentException($"The \"{paramName}\" parameter is null or an empty string.", paramName);
