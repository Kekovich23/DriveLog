using AutoMapper;
using DriveLog.Application.Models.Car;
using DriveLog.Application.Services.Base;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;

namespace DriveLog.Application.Services;

public class CarApplicationService(IUnitOfWork unitOfWork, ICarRepository repository, IMapper mapper)
    : ApplicationService<Car, CarModel, CarCreateModel, Guid, ICarRepository>(unitOfWork, repository, mapper), ICarApplicationService {
    protected override async Task<Car?> CreateAsync(CarCreateModel model, CancellationToken cancellationToken)
        => await _repository.GetByNumberAsync(model.Number) != null ? null : new Car(Guid.CreateVersion7(), new(model.Number));

    protected override async Task<bool> UpdateAsync(Car entity, CarModel model, CancellationToken cancellationToken) {
        if (await _repository.GetByNumberAsync(model.Number) != null) {
            return false;
        }

        entity.ChangeNumber(new(model.Number));

        return true;
    }
}
