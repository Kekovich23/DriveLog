using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.ValueObjects;

public record FullName {
    public const int MaxNameLength = 20;
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public FullName(string firstName, string lastName) {
        ValidateName(firstName, nameof(firstName));
        ValidateName(lastName, nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    private static void ValidateName(string value, string paramName) {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new StringIsNullOrEmptyException(paramName);
        }

        if (value.Length > MaxNameLength) {
            throw new StringLengthExceedsLimit(MaxNameLength, paramName);
        }
    }

    public override string ToString() => string.Join(" ", FirstName, LastName);
}
