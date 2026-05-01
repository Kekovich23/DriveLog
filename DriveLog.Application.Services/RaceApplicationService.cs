using AutoMapper;
using DriveLog.Application.Models.Race;
using DriveLog.Application.Services.Base;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;

namespace DriveLog.Application.Services;

public class RaceApplicationService(IUnitOfWork unitOfWork,
                                    IRaceRepository repository,
                                    ITrackRepository trackRepository,
                                    IMapper mapper)
    : ApplicationService<Race, RaceModel, RaceCreateModel, Guid, IRaceRepository>(unitOfWork, repository, mapper),
      IRaceApplicationService {
    protected override async Task<Race?> CreateAsync(RaceCreateModel model, CancellationToken cancellationToken)
        => (await trackRepository.GetByIdAsync(model.TrackId, cancellationToken))?.CreateRace(model.Date);

    protected override Task<bool> UpdateAsync(Race entity, RaceModel model, CancellationToken cancellationToken) {
        entity.ChangeDate(model.Date);

        return Task.FromResult(true);
    }
}
