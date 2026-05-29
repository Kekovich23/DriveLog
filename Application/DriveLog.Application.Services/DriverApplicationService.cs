using AutoMapper;
using DriveLog.Application.Models.Driver;
using DriveLog.Application.Services.Base;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;

namespace DriveLog.Application.Services;

public class DriverApplicationService(IUnitOfWork unitOfWork, IDriverRepository repository, IMapper mapper)
    : ApplicationService<Driver, DriverModel, DriverCreateModel, Guid, IDriverRepository>(unitOfWork, repository, mapper),
    IDriverApplicationService {
    protected override async Task<Driver?> CreateAsync(DriverCreateModel model, CancellationToken cancellationToken)
        => await _repository.GetByNumberAsync(model.Number) != null ? null : new(Guid.CreateVersion7(), new(model.FirstName, model.LastName), new(model.Number));

    protected override async Task<bool> UpdateAsync(Driver entity, DriverModel model, CancellationToken cancellationToken) {
        if (await _repository.GetByNumberAsync(model.Number) != null) {
            return false;
        }

        entity.ChangeName(new(model.FirstName, model.LastName));
        entity.ChangeNumber(new(model.Number));

        return true;
    }
}
