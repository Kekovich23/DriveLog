using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.ValueObjects;

public record Name {
    public string Value { get; init; }
    public Name(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new StringIsNullOrEmptyException(nameof(name));
        }

        if (name.Length > 20) {
            throw new StringLengthExceedsLimit(20, nameof(name));
        }

        Value = name;
    }
}
