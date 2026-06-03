using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.RaceLap;

public record RaceLapCreateModel(Guid RaceId, Guid DriverId, Guid CarId, int LapNumber, TimeSpan LapTime) : ICreateModel;
