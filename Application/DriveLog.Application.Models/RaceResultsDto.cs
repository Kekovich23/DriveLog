namespace DriveLog.Application.Models;

public record RaceResultsDto(Guid RaceId, string TrackName, DateTimeOffset Date, List<DriverResultDto> Leaderboard);