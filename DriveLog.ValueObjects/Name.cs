using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.ValueObjects;

public record Name {
    public const int MaxNameLength = 20;
    public string Value { get; init; }
    public Name(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new StringIsNullOrEmptyException(nameof(name));
        }

        if (name.Length > MaxNameLength) {
            throw new StringLengthExceedsLimit(MaxNameLength, nameof(name));
        }

        Value = name;
    }
}
