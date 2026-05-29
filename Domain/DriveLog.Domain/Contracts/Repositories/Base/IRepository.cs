using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Contracts.Repositories.Base;

public interface IRepository<TEntity, in TId>
    where TEntity : BaseEntity<TId>
    where TId : notnull {
    ValueTask<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity entity);
}