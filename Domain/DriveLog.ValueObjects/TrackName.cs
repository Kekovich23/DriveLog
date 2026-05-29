namespace DriveLog.ValueObjects;

public record TrackName {
    public const int MaxLength = 100;
    public TrackName(string value) {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentException("Track name cannot be null or whitespace.");
        }

        if (value.Length > MaxLength) {
            throw new ArgumentException("Track name cannot exceed 100 characters.");
        }

        Value = value;
    }

    public string Value { get; set; }
}
