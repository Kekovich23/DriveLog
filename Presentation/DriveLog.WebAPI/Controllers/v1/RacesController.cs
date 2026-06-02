using DriveLog.Application.CommandHandler;
using DriveLog.Application.Models;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class RacesController(CreateRaceCommandHandler createHandler,
                             RegisterDriverCommandHandler registerHandler,
                             StartRaceCommandHandler startHandler,
                             RecordLapTimeCommandHandler recordLapHandler,
                             FinishRaceCommandHandler finishHandler,
                             IRaceQueryService queryService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] RaceRequestModel model, CancellationToken cancellationToken) {
        var race = await createHandler.HandleAsync(new CreateRaceCommand(model.TrackId, model.Date), cancellationToken);

        return CreatedAtRoute("GetRaceById", new { id = race.Id }, race);
    }

    [HttpPost("{id}/drivers")]
    public async Task<IActionResult> RegisterDriverAsync(Guid id, [FromBody] RegisterDriverRequestModel model, CancellationToken cancellationToken) {
        await registerHandler.HandleAsync(new RegisterDriverCommand(id, model.DriverId, model.CarId), cancellationToken);

        return Ok(new { Message = "Driver registered successfully." });
    }

    [HttpPost("{id}/start")]
    public async Task<IActionResult> StartRaceAsync(Guid id, CancellationToken cancellationToken) {
        await startHandler.HandleAsync(new StartRaceCommand(id), cancellationToken);

        return Ok(new { Message = "Race started successfully." });
    }

    [HttpPost("{id}/laps")]
    public async Task<IActionResult> RecordLapTimeAsync(Guid id, [FromBody] RecordLapTimeRequestModel model, CancellationToken cancellationToken) {
        await recordLapHandler.HandleAsync(new RecordLapTimeCommand(id, model.DriverId, model.Duration), cancellationToken);

        return NoContent();
    }

    [HttpPost("{id}/finish")]
    public async Task<IActionResult> FinishRaceAsync(Guid id, CancellationToken cancellationToken) {
        await finishHandler.HandleAsync(new FinishRaceCommand(id), cancellationToken);

        return Ok(new { Message = "Race finished successfully." });
    }

    [HttpGet("{id}/results")]
    public async Task<IActionResult> GetRaceResultsAsync(Guid id, CancellationToken cancellationToken) {
        var results = await queryService.GetTotalResultsAsync(id, cancellationToken);

        return results is not null ? Ok(results) : NotFound("Race results not found.");
    }

    [HttpGet("{id}/best-laps")]
    public async Task<IActionResult> GetBestLapsAsync(Guid id, CancellationToken cancellationToken) {
        var bestLaps = await queryService.GetBestLapTimeAsync(id, cancellationToken);

        return bestLaps is not null ? Ok(bestLaps) : NotFound("Best laps not found.");
    }
}
