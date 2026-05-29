using DriveLog.Application.Models;

namespace DriveLog.Application.Services.Contracts;

public interface IRaceQueryService {
    Task<RaceResultsDto?> GetTotalResultsAsync(Guid raceId, CancellationToken cancellationToken = default);
    Task<BestTimeDto?> GetBestLapTimeAsync(Guid raceId, CancellationToken cancellationToken = default);
}
