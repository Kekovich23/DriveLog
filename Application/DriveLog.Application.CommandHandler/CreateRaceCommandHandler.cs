using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Application.Models.Race;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Application.CommandHandler;

public class CreateRaceCommandHandler(ITrackRepository trackRepository, IRaceRepository raceRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateRaceCommand, RaceModel> {
    public async Task<RaceModel> HandleAsync(CreateRaceCommand command, CancellationToken cancellationToken = default) {
        var track = await trackRepository.GetByIdAsync(command.TrackId, cancellationToken)
            ?? throw new EntityNotFoundException($"Track with ID {command.TrackId} not found.");

        var race = new Race(Guid.CreateVersion7(), track.Id, new(command.Date));

        raceRepository.Add(race);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new RaceModel(race.Id, race.TrackId, race.Date.Value);
    }
}
