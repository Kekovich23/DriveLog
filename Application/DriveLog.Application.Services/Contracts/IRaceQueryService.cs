using DriveLog.Application.Models;
using DriveLog.Application.Models.Pagination;
using DriveLog.Application.Models.Race;

namespace DriveLog.Application.Services.Contracts;

public interface IRaceQueryService {
    Task<RaceModel?> GetRaceByIdAsync(Guid raceId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<RaceModel>> GetAllRacesAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task<RaceResultsDto?> GetTotalResultsAsync(Guid raceId, CancellationToken cancellationToken = default);
    Task<BestTimeDto?> GetBestLapTimeAsync(Guid raceId, CancellationToken cancellationToken = default);
}
