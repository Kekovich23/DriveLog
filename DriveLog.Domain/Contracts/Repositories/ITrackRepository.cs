using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities;

namespace DriveLog.Domain.Contracts.Repositories;

public interface ITrackRepository : IRepository<Track, Guid> {
    Task<Track?> GetByNameAsync(string name);
}
