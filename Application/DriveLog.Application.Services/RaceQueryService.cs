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
                              e.Driver,
                              e.Car,
                              LapNumber = l.Id.Value,
                              l.Time.Duration
                          }))).OrderBy(l => l.Duration).FirstOrDefaultAsync(cancellationToken);

        return bestLapData == null
            ? null
            : new BestTimeDto(
            $"{bestLapData.Driver.Name.FirstName} {bestLapData.Driver.Name.LastName}",
            bestLapData.Car.Number.Value,
            bestLapData.LapNumber,
            bestLapData.Duration
        );
    }
    public Task<RaceResultsDto?> GetTotalResultsAsync(Guid raceId, CancellationToken cancellationToken = default)
        => context.Races.AsNoTracking()
                        .Where(r => r.Id == raceId)
                        .Select(r => new RaceResultsDto(r.Id,
                                                        context.Tracks.First(t => t.Id == r.Track.Id).Name.Value,
                                                        r.Date.Value,
                                                        r.Entries.Select(e => new DriverResultDto(
                                                            $"{context.Drivers.First(d => d.Id == e.Driver.Id).Name.FirstName} {context.Drivers.First(d => d.Id == e.Driver.Id).Name.LastName}",
                                                            context.Cars.First(c => c.Id == e.Car.Id).Number.Value,
                                                            e.Laps.Count,
                                                            e.Laps.Select(l => l.Time.Duration).Aggregate((t1, t2) => t1 + t2)
                                                            )
                                                        )
                            .OrderByDescending(d => d.TotalLaps)
                            .ThenBy(d => d.TotalLaps)
                            .ToList()))
        .FirstOrDefaultAsync(cancellationToken);
}
