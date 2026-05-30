using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Application.CommandHandler;

public class RecordLapTimeCommandHandler(IRaceRepository raceRepository, IDriverRepository driverRepository, IUnitOfWork unitOfWork) : ICommandHandler<RecordLapTimeCommand> {
    public async Task HandleAsync(RecordLapTimeCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken)
            ?? throw new EntityNotFoundException("Race not found.");

        var driver = await driverRepository.GetByIdAsync(command.DriverId, cancellationToken)
            ?? throw new EntityNotFoundException("Driver not found.");

        race.RecordLapTime(driver, new(command.Duration));

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
