namespace DriveLog.WebAPI.Models.Responses;

/// <summary>
/// Response model for driver information.
/// </summary>
public record DriverResponseModel {
    /// <summary>
    /// Unique identifier for the driver.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Driver's first name.
    /// </summary>
    public string? FirstName { get; init; }
    
    /// <summary>
    /// Driver's last name.
    /// </summary>
    public string? LastName { get; init; }
    
    /// <summary>
    /// Driver number.
    /// </summary>
    public int Number { get; init; }
}
