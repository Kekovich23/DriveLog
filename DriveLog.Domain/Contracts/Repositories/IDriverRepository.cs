using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities;

namespace DriveLog.Domain.Contracts.Repositories;

public interface IDriverRepository : IRepository<Driver, Guid>;
