using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;

namespace DriveLog.Application.CommandHandler;

public class FinishRaceCommandHandler(IRaceRepository raceRepository, IUnitOfWork unitOfWork) : ICommandHandler<FinishRaceCommand> {
    public async Task HandleAsync(FinishRaceCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken) 
            ?? throw new KeyNotFoundException();

        race.FinishRace(DateTimeOffset.UtcNow);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
