using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities;
using DriveLog.ValueObjects;

namespace DriveLog.Domain.Contracts.Repositories;

public interface IDriverRepository : IRepository<Driver, Guid> {
    Task<Driver?> GetByNumberAsync(DriverNumber number);
}
