using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Race;

public record RaceCreateModel(Guid TrackId, DateTimeOffset Date) : ICreateModel;
