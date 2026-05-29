using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;

namespace DriveLog.Application.CommandHandler;

public class RecordLapTimeCommandHandler(IRaceRepository raceRepository, IUnitOfWork unitOfWork) : ICommandHandler<RecordLapTimeCommand> {
    public async Task HandleAsync(RecordLapTimeCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken)
            ?? throw new KeyNotFoundException();

        race.RecordLapTime(command.DriverId, new(command.Duration));

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
