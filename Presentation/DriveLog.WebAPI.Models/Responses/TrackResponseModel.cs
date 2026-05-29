namespace DriveLog.WebAPI.Models.Responses;

/// <summary>
/// Response model for track information.
/// </summary>
public record TrackResponseModel {
    /// <summary>
    /// Unique identifier for the track.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Track name.
    /// </summary>
    public string? Name { get; init; }
}
