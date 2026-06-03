using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories;

public class DriverRepository(DriveLogDbContext dbContext) : Repository<Driver, Guid>(dbContext), IDriverRepository {
    public Task<Driver?> GetByNumberAsync(DriverNumber number) => _dbSet.FirstOrDefaultAsync(x => x.Number == number);
}
