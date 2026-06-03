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
        var raceData = await context.Races.AsNoTracking()
                                             .Where(r => r.Id == raceId)
                                             .SelectMany(r => r.Entries.Where(e => e.Laps.Count != 0).Select(e => new {
                                                 e.DriverId,
                                                 e.CarId,
                                                 e.Laps
                                             }))
                                             .ToListAsync(cancellationToken);



        if (raceData == null || raceData.Count == 0) {
            return null;
        }

        var bestLapData = raceData.Select(x => new {
            x.DriverId,
            x.CarId,
            BestLap = x.Laps.OrderBy(l => l.Time.Duration).First(),
        })
                                  .OrderByDescending(x => x.BestLap.Id.Value)
                                  .ThenBy(x => x.BestLap.Time.Duration)
                                  .First();

        var driver = await context.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.Id == bestLapData.DriverId, cancellationToken)
            ?? throw new EntityNotFoundException("Driver not found.");
        var car = await context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == bestLapData.CarId, cancellationToken)
            ?? throw new EntityNotFoundException("Car not found.");

        return new BestTimeDto(
            driver.Name.ToString(),
            car.Number.Value,
            bestLapData.BestLap.Id.Value,
            bestLapData.BestLap.Time.Duration
        );
    }

    public async Task<RaceResultsDto?> GetTotalResultsAsync(Guid raceId, CancellationToken cancellationToken = default) {
        var raceResults = await context.Races.AsNoTracking()
                                             .Where(r => r.Id == raceId)
                                             .Select(r => new {
                                                 r.Id,
                                                 TrackName = context.Tracks.First(t => t.Id == r.TrackId).Name,
                                                 r.Date,
                                                 Entries = r.Entries.Select(e => new {
                                                     Driver = context.Drivers.First(d => d.Id == e.DriverId),
                                                     Car = context.Cars.First(c => c.Id == e.CarId),
                                                     e.Laps,
                                                 })
                                             })
                                             .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return raceResults == null
            ? null
            : new(raceResults.Id,
                  raceResults.TrackName.Value,
                  raceResults.Date.Value,
                  [.. raceResults.Entries.Select(e => new DriverResultDto(e.Driver.Name.ToString(),
                                                                          e.Car.Number.Value,
                                                                          e.Laps.Count,
                                                                          e.Laps.Select(l => l.Time.Duration).Aggregate((t1, t2) => t1 + t2)))
                                         .OrderByDescending(x => x.TotalLaps)
                                         .ThenBy(x => x.TotalTime)]);
    }
}
