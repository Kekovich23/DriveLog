using DriveLog.Application.Models;
using DriveLog.Application.Models.Pagination;
using DriveLog.Application.Models.Race;
using DriveLog.Application.Services.Contracts;
using DriveLog.Infrastructure;
using DriveLog.ValueObjects.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Application.Services;

public class RaceQueryService(DriveLogDbContext context) : IRaceQueryService {
    public async Task<RaceModel?> GetRaceByIdAsync(Guid raceId, CancellationToken cancellationToken = default) {
        var race = await context.Races.AsNoTracking().FirstOrDefaultAsync(r => r.Id == raceId, cancellationToken);

        return race == null ? null : new RaceModel(race.Id, race.TrackId, race.Date.Value);
    }

    public async Task<PaginatedResponse<RaceModel>> GetAllRacesAsync(int skip, int take, CancellationToken cancellationToken = default)
        => new(await context.Races.AsNoTracking()
                                  .Skip(skip)
                                  .Take(take)
                               .Select(r => new RaceModel(r.Id, r.TrackId, r.Date.Value))
                                  .ToListAsync(cancellationToken),
               await context.Races.CountAsync(cancellationToken));

    public async Task<BestTimeDto?> GetBestLapTimeAsync(Guid raceId, CancellationToken cancellationToken = default) {
        var bestLapData = await context.Races.AsNoTracking()
                          .Where(r => r.Id == raceId)
                          .SelectMany(r => r.Entries.SelectMany(e => e.Laps.Select(l => new {
                              e.DriverId,
                              e.CarId,
                              LapNumber = l.Id.Value,
                              l.Time.Duration
                          }))).OrderBy(l => l.Duration).FirstOrDefaultAsync(cancellationToken);

        if (bestLapData == null) {
            return null;
        }

        var driver = await context.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.Id == bestLapData.DriverId, cancellationToken)
            ?? throw new EntityNotFoundException("Driver not found.");
        var car = await context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == bestLapData.CarId, cancellationToken)
            ?? throw new EntityNotFoundException("Car not found.");

        return bestLapData == null
            ? null
            : new BestTimeDto(
            $"{driver.Name.FirstName} {driver.Name.LastName}",
            car.Number.Value,
            bestLapData.LapNumber,
            bestLapData.Duration
        );
    }

    public Task<RaceResultsDto?> GetTotalResultsAsync(Guid raceId, CancellationToken cancellationToken = default)
        => context.Races.AsNoTracking()
                        .Where(r => r.Id == raceId)
                        .Select(r => new RaceResultsDto(r.Id,
                                                        context.Tracks.First(t => t.Id == r.TrackId).Name.Value,
                                                        r.Date.Value,
                                                        r.Entries.Select(e => new DriverResultDto(
                                                            $"{context.Drivers.First(d => d.Id == e.DriverId).Name.FirstName} {context.Drivers.First(d => d.Id == e.DriverId).Name.LastName}",
                                                            context.Cars.First(c => c.Id == e.CarId).Number.Value,
                                                            e.Laps.Count,
                                                            e.Laps.Select(l => l.Time.Duration).Aggregate((t1, t2) => t1 + t2)
                                                            )
                                                        )
                            .OrderByDescending(d => d.TotalLaps)
                            .ThenBy(d => d.TotalLaps)
                            .ToList()))
        .FirstOrDefaultAsync(cancellationToken);
}
