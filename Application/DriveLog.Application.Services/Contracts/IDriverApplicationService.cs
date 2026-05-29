using DriveLog.Application.Models.Driver;
using DriveLog.Application.Services.Contracts.Base;

namespace DriveLog.Application.Services.Contracts;

public interface IDriverApplicationService : IApplicationService<DriverModel, DriverCreateModel, Guid>;
