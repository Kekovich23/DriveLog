using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;

namespace DriveLog.Application.CommandHandler;

public class StartRaceCommandHandler(IRaceRepository raceRepository, IUnitOfWork unitOfWork) : ICommandHandler<StartRaceCommand> {
    public async Task HandleAsync(StartRaceCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken)
            ?? throw new KeyNotFoundException();

        race.StartRace(DateTimeOffset.UtcNow);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
