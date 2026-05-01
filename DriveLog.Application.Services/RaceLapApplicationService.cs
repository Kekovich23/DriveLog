using AutoMapper;
using DriveLog.Application.Models.RaceLap;
using DriveLog.Application.Services.Base;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;

namespace DriveLog.Application.Services;

public class RaceLapApplicationService(IUnitOfWork unitOfWork,
                                       IRaceRepository raceRepository,
                                       IDriverRepository driverRepository,
                                       ICarRepository carRepository,
                                       IRaceLapRepository repository,
                                       IMapper mapper)
    : ApplicationService<RaceLap, RaceLapModel, RaceLapCreateModel, Guid, IRaceLapRepository>(unitOfWork, repository, mapper), 
    IRaceLapApplicationService {
    protected override async Task<RaceLap?> CreateAsync(RaceLapCreateModel model, CancellationToken cancellationToken) {
        var car = await carRepository.GetByIdAsync(model.CarId, cancellationToken);
        if (car == null) {
            return null;
        }

        var driver = await driverRepository.GetByIdAsync(model.DriverId, cancellationToken);
        if (driver == null) {
            return null;
        }

        return (await raceRepository.GetByIdAsync(model.RaceId, cancellationToken))?.CreateRaceLap(driver.Id,
                                                                                                   car.Id,
                                                                                                   model.LapNumber,
                                                                                                   model.LapTime);
    }

    protected override async Task<bool> UpdateAsync(RaceLap entity, RaceLapModel model, CancellationToken cancellationToken) {
        var car = await carRepository.GetByIdAsync(model.CarId, cancellationToken);
        if (car == null) {
            return false;
        }

        entity.ChangeCar(car.Id);

        var driver = await driverRepository.GetByIdAsync(model.DriverId, cancellationToken);
        if (driver == null) {
            return false;
        }

        entity.ChangeDriver(driver.Id);

        var race = await raceRepository.GetByIdAsync(model.RaceId, cancellationToken);
        if (race == null) {
            return false;
        }

        entity.ChangeRace(race.Id);

        entity.ChangeLapNumber(model.LapNumber);
        entity.ChangeLapTime(model.LapTime);

        return true;
    }
}
