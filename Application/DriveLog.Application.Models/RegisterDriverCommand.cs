namespace DriveLog.Application.Models;

public record RegisterDriverCommand(Guid RaceId, Guid DriverId, Guid CarId);
