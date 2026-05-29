using DriveLog.Application.Models.Track;
using DriveLog.Application.Services.Contracts.Base;

namespace DriveLog.Application.Services.Contracts;

public interface ITrackApplicationService : IApplicationService<TrackModel, TrackCreateModel, Guid>;
