namespace DriveLog.Application.Models;

public record DriverResultDto(string DriverName, int CarNumber, int TotalLaps, TimeSpan TotalTime);
