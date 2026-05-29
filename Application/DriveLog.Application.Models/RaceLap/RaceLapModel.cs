using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.RaceLap;

public record RaceLapModel(Guid Id, Guid RaceId, Guid DriverId, Guid CarId, int LapNumber, TimeSpan LapTime) : IModel<Guid>;