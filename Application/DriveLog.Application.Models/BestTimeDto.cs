namespace DriveLog.Application.Models;

public record BestTimeDto(string DriverName, int CarNumber, int LapNumber, TimeSpan Duration);
