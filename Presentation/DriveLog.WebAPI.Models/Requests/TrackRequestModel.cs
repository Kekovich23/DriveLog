namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for track information.
/// </summary>
public record TrackRequestModel {
    /// <summary>
    /// Track name.
    /// </summary>
    public string? Name { get; init; }
}
