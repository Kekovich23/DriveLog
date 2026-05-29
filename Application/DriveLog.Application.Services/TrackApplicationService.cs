using AutoMapper;
using DriveLog.Application.Models.Track;
using DriveLog.Application.Services.Base;
using DriveLog.Application.Services.Contracts;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories;
using DriveLog.Domain.Entities;

namespace DriveLog.Application.Services;

public class TrackApplicationService(IUnitOfWork unitOfWork, ITrackRepository repository, IMapper mapper) 
    : ApplicationService<Track, TrackModel, TrackCreateModel, Guid, ITrackRepository>(unitOfWork, repository, mapper), 
    ITrackApplicationService {
    protected override Task<Track?> CreateAsync(TrackCreateModel model, CancellationToken cancellationToken)
        => Task.FromResult<Track?>(new Track(model.Name));
    protected override Task<bool> UpdateAsync(Track entity, TrackModel model, CancellationToken cancellationToken) {
        entity.ChangeName(model.Name);

        return Task.FromResult(true);
    }
}
