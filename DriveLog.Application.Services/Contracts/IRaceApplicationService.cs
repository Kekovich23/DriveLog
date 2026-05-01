using DriveLog.Application.Models.Race;
using DriveLog.Application.Services.Contracts.Base;

namespace DriveLog.Application.Services.Contracts;

public interface IRaceApplicationService : IApplicationService<RaceModel, RaceCreateModel, Guid>;
