using DriveLog.Domain.Entities.Base;

namespace DriveLog.Domain.Contracts.Repositories.Base;

public interface IRepository<TEntity, in TId>
    where TEntity : AggregateEntity<TId>
    where TId : notnull {
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    void Add(TEntity entity);
    void Delete(TEntity entity);
}