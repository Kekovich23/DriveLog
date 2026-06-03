using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories;

public class RaceRepository(DriveLogDbContext dbContext) : Repository<Race, Guid>(dbContext), IRaceRepository {
    public override Task<Race?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => _dbSet.Include(x => x.Entries)
                 .ThenInclude(x => x.Laps)
                 .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
}