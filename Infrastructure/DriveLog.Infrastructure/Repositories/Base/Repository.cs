using DriveLog.Domain.Contracts.Repositories.Base;
using DriveLog.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure.Repositories.Base;

public abstract class Repository<TEntity, TId>(DriveLogDbContext dbContext) : IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : notnull {
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        => (await _dbSet.AddAsync(entity, cancellationToken)).Entity;

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public ValueTask<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        => _dbSet.FindAsync([id], cancellationToken: cancellationToken);
}
