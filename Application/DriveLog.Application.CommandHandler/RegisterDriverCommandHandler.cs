using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Application.CommandHandler;

public class RegisterDriverCommandHandler(IRaceRepository raceRepository, IUnitOfWork unitOfWork) : ICommandHandler<RegisterDriverCommand> {
    public async Task HandleAsync(RegisterDriverCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken) ?? throw new EntityNotFoundException("Race not found.");

        race.RegisterDriver(command.DriverId, command.CarId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
