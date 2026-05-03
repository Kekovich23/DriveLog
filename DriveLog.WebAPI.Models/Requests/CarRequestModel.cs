namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for car information.
/// </summary>
public record CarRequestModel {
    /// <summary>
    /// Unique identifier for the car.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Car number.
    /// </summary>
    public int Number { get; init; }
}
