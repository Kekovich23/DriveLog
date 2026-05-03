namespace DriveLog.WebAPI.Models.Responses;

/// <summary>
/// Response model for race information.
/// </summary>
public record RaceResponseModel {
    /// <summary>
    /// Unique identifier for the race.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Date and time when the race was held.
    /// </summary>
    public DateTimeOffset Date { get; init; }
}
