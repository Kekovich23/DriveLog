namespace DriveLog.WebAPI.Models.Requests;

/// <summary>
/// Request model for driver information.
/// </summary>
public record DriverRequestModel {
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
