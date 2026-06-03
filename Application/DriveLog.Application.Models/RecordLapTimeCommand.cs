namespace DriveLog.Application.Models;

public record RecordLapTimeCommand(Guid RaceId, Guid DriverId, TimeSpan Duration);
