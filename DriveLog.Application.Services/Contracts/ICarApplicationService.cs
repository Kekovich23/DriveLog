using DriveLog.Application.Models.Car;
using DriveLog.Application.Services.Contracts.Base;

namespace DriveLog.Application.Services.Contracts;

public interface ICarApplicationService : IApplicationService<CarModel, CarCreateModel, Guid>;
