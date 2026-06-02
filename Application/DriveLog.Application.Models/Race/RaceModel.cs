using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Race;

public record RaceModel(Guid Id, Guid TrackId, DateTimeOffset Date) : IModel<Guid>;
