using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Track;

public record TrackModel(Guid Id, string Name) : IModel<Guid>;