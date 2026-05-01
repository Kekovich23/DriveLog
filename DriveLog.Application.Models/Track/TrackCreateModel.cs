using DriveLog.Application.Models.Base;

namespace DriveLog.Application.Models.Track;

public record TrackCreateModel(string Name) : ICreateModel;
