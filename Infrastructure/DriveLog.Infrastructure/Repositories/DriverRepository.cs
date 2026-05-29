using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories;

public class DriverRepository(DriveLogDbContext dbContext) : Repository<Driver, Guid>(dbContext), IDriverRepository {
    public Task<Driver?> GetByNameAsync(string name) => _dbSet.FirstOrDefaultAsync(x => x.FullName.FirstName == name
                                                                                        || x.FullName.LastName == name
                                                                                        || x.FullName.FirstName + " " + x.FullName.LastName == name);
    public Task<Driver?> GetByNumberAsync(int number) => _dbSet.FirstOrDefaultAsync(x => x.Number.Value == number);
}
