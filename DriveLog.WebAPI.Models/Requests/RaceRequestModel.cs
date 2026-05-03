namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for race information.
/// </summary>
public record RaceRequestModel {
    /// <summary>
    /// Date and time when the race was held.
    /// </summary>
    public DateTimeOffset Date { get; init; }
}
