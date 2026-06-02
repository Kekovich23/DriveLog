using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;
using DriveLog.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories;

public class CarRepository(DriveLogDbContext dbContext) : Repository<Car, Guid>(dbContext), ICarRepository {
    public Task<Car?> GetByNumberAsync(CarNumber number) => _dbSet.FirstOrDefaultAsync(x => x.Number == number);
}
