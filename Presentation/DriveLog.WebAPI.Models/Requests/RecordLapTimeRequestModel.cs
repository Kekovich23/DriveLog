namespace DriveLog.WebAPI.Models.Requests;

public record RecordLapTimeRequestModel {
    public Guid DriverId { get; init; }
    public TimeSpan Duration { get; init; }
}
