namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for car information.
/// </summary>
public record CarRequestModel {
    /// <summary>
    /// Car number.
    /// </summary>
    public int Number { get; init; }
}
