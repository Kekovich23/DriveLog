namespace DriveLog.Application.Models;

public record CreateRaceCommand(Guid TrackId, DateTimeOffset Date);
