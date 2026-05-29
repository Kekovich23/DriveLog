using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Race;

public record RaceModel(Guid Id, DateTimeOffset Date) : IModel<Guid>;
