namespace DriveLog.WebAPI.Models.Requests;

public record RegisterDriverRequestModel {
    public Guid DriverId { get; init; }
    public Guid CarId { get; init; }
}
