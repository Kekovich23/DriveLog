namespace DriveLog.ValueObjects;

public record DriverName {
    public const int MaxLength = 50;
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DriverName(string firstName, string lastName) {
        ValidateName(firstName, nameof(firstName));
        ValidateName(lastName, nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    private static void ValidateName(string value, string paramName) {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentException("Name cannot be null or whitespace.", paramName);
        }

        if (value.Length > MaxLength) {
            throw new ArgumentException($"Name cannot exceed {MaxLength} characters.", paramName);
        }
    }

    public override string ToString() => string.Join(" ", FirstName, LastName);
}
