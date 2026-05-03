namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for race lap information.
/// </summary>
public record RaceLapRequestModel {
    /// <summary>
    /// Unique identifier for the lap.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Race identifier.
    /// </summary>
    public Guid RaceId { get; init; }
    
    /// <summary>
    /// Driver identifier.
    /// </summary>
    public Guid DriverId { get; init; }
    
    /// <summary>
    /// Car identifier.
    /// </summary>
    public Guid CarId { get; init; }
    
    /// <summary>
    /// Lap number.
    /// </summary>
    public int LapNumber { get; init; }
    
    /// <summary>
    /// Time taken to complete the lap.
    /// </summary>
    public TimeSpan LapTime { get; init; }
}
