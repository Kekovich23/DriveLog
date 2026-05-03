namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for race information.
/// </summary>
public record RaceRequestModel {
    /// <summary>
    /// Unique identifier for the race.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Date and time when the race was held.
    /// </summary>
    public DateTimeOffset Date { get; init; }
}
