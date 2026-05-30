using DriveLog.Application.CommandHandler.Base;
using DriveLog.Application.Models;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.ValueObjects.Exceptions;

namespace DriveLog.Application.CommandHandler;

public class RegisterDriverCommandHandler(IRaceRepository raceRepository,
                                          ICarRepository carRepository,
                                          IDriverRepository driverRepository,
                                          IUnitOfWork unitOfWork) : ICommandHandler<RegisterDriverCommand> {
    public async Task HandleAsync(RegisterDriverCommand command, CancellationToken cancellationToken = default) {
        var race = await raceRepository.GetByIdAsync(command.RaceId, cancellationToken) ?? throw new EntityNotFoundException("Race not found.");

        var driver = await driverRepository.GetByIdAsync(command.DriverId, cancellationToken)
            ?? throw new EntityNotFoundException("Driver not found.");

        var car = await carRepository.GetByIdAsync(command.CarId, cancellationToken)
            ?? throw new EntityNotFoundException("Car not found.");

        race.RegisterDriver(driver, car);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
