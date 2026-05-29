using DriveLog.Application.Models;
using DriveLog.Application.Services.Contracts;
using DriveLog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Application.Services;

public class RaceQueryService(DriveLogDbContext context) : IRaceQueryService {
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

        var driver = await context.Drivers.AsNoTracking()
                                          .FirstAsync(d => d.Id == bestLapData.DriverId, cancellationToken);
        var car = await context.Cars.AsNoTracking()
                                    .FirstAsync(c => c.Id == bestLapData.CarId, cancellationToken);

        return new BestTimeDto(
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
