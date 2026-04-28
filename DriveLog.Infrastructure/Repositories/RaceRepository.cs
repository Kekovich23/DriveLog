using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;

namespace DriveLog.Infrastructure.Repositories;

public class RaceRepository(DriveLogDbContext dbContext) : Repository<Race, Guid>(dbContext), IRaceRepository;