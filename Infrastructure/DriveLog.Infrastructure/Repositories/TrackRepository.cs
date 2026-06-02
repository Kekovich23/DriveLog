using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;

namespace DriveLog.Infrastructure.Repositories;

public class TrackRepository(DriveLogDbContext dbContext) : Repository<Track, Guid>(dbContext), ITrackRepository;
