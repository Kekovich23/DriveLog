using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Contracts.Repositories;

public interface ICarRepository : IRepository<Car, Guid> {
    Task<Car?> GetByNumberAsync(CarNumber number);
}
