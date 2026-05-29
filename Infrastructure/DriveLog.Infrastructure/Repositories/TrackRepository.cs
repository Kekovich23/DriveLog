using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories;

public class TrackRepository(DriveLogDbContext dbContext) : Repository<Track, Guid>(dbContext), ITrackRepository {
    public Task<Track?> GetByNameAsync(string name) => _dbSet.FirstOrDefaultAsync(x => x.Name.Value == name);
}
