using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories.Base;

public abstract class Repository<TEntity, TId>(DriveLogDbContext dbContext) : IRepository<TEntity, TId>
    where TEntity : AggregateEntity<TId>
    where TId : notnull {
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async void Add(TEntity entity) => _dbSet.Add(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public virtual Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        => _dbSet.FindAsync([id], cancellationToken: cancellationToken).AsTask();
}
