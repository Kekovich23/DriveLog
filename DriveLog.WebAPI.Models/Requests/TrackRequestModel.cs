namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for track information.
/// </summary>
public record TrackRequestModel {
    /// <summary>
    /// Unique identifier for the track.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Track name.
    /// </summary>
    public string? Name { get; init; }
}
