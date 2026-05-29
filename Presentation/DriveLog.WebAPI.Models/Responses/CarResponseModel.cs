namespace DriveLog.WebAPI.Models.Responses;

/// <summary>
/// Response model for car information.
/// </summary>
public record CarResponseModel {
    /// <summary>
    /// Unique identifier for the car.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Car number.
    /// </summary>
    public int Number { get; init; }
}
