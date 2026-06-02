using AutoMapper;
using DriveLog.Application.Models.Base;
using DriveLog.Application.Services.Contracts.Base;
using DriveLog.Domain.Contracts;
using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities.Base;

namespace DriveLog.Application.Services.Base;

public abstract class ApplicationService<TEntity, TModel, TCreateModel, TId, TRepository>(IUnitOfWork unitOfWork,
                                                                                          TRepository repository,
                                                                                          IMapper mapper)
    : IApplicationService<TModel, TCreateModel, TId>
    where TEntity : AggregateEntity<TId>
    where TModel : class, IModel<TId>
    where TId : struct, IEquatable<TId>
    where TCreateModel : ICreateModel
    where TRepository : IRepository<TEntity, TId> {
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly TRepository _repository = repository;
    protected readonly IMapper _mapper = mapper;

    public async Task<TModel?> CreateModelAsync(TCreateModel createModel, CancellationToken cancellationToken = default) {
        var entity = await CreateAsync(createModel, cancellationToken);
        if (entity == null) {
            return null;
        }

        _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TModel>(entity);
    }

    public async Task<bool> DeleteModelAsync(TId id, CancellationToken cancellationToken = default) {
        var model = await _repository.GetByIdAsync(id, cancellationToken);
        if (model != null) {
            _repository.Delete(model);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }

    public async Task<TModel?> GetModelByIdAsync(TId id, CancellationToken cancellationToken = default)
        => _mapper.Map<TModel?>(await _repository.GetByIdAsync(id, cancellationToken));

    public async Task<IReadOnlyList<TModel>> GetAllModelsAsync(CancellationToken cancellationToken = default)
        => _mapper.Map<List<TModel>>(await _repository.GetAllAsync(cancellationToken));

    public async Task<bool> UpdateModelAsync(TModel model, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetByIdAsync(model.Id, cancellationToken);

        if (entity == null || !await UpdateAsync(entity, model, cancellationToken)) {
            return false;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    protected abstract Task<TEntity?> CreateAsync(TCreateModel model, CancellationToken cancellationToken);
    protected abstract Task<bool> UpdateAsync(TEntity entity, TModel model, CancellationToken cancellationToken);
}
