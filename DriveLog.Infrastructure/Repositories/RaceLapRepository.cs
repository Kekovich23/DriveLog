using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.Infrastructure.Repositories.Base;

namespace DriveLog.Infrastructure.Repositories;

public class RaceLapRepository(DriveLogDbContext dbContext) : Repository<RaceLap, Guid>(dbContext), IRaceLapRepository;
