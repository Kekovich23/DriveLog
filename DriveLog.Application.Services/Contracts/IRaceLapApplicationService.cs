using DriveLog.Application.Models.RaceLap;
using DriveLog.Application.Services.Contracts.Base;

namespace DriveLog.Application.Services.Contracts;

public interface IRaceLapApplicationService : IApplicationService<RaceLapModel, RaceLapCreateModel, Guid>;
