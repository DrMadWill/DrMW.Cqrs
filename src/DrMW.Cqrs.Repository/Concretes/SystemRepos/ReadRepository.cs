using System.Linq.Expressions;
using AutoMapper;
using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Concretes.SystemRepos;

public class ReadRepository<TEntity, TPrimary> : IReadRepository<TEntity, TPrimary>
    where TEntity : class, IBaseEntity<TPrimary>
{
    protected readonly AppSelectDb DbContext;

    /// <summary>
    /// Gets the table of the TEntity type from the database context.
    /// </summary>
    public DbSet<TEntity> Table { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadRepository{TEntity, TPrimary}"/> class.
    /// </summary>
    /// <param name="dbContext">The database context to be used by the repository.</param>
    public ReadRepository(AppSelectDb dbContext)
    {
        DbContext = dbContext;
        Table = dbContext.Set<TEntity>();
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
   
    /// <summary>
    /// Protected implementation of Dispose pattern.
    /// </summary>
    /// <param name="disposing">Indicates whether the method call comes from a Dispose method (its value is true) or from a finalizer (its value is false).</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Free any other managed objects here.
        }
    }
    
    /// <summary>
    /// Destructor for ReadRepository.
    /// </summary>
    ~ReadRepository()
    {
        Dispose(false);
    }
    
    /// <summary>
    /// Retrieves an IQueryable for all entities of type TEntity, optionally including deleted entities and/or applying tracking.
    /// </summary>
    /// <param name="deleted">If true, the query will include entities that are marked as deleted. Default is false.</param>
    /// <returns>An IQueryable of all entities of type TEntity.</returns>
    public virtual IQueryable<TEntity> GetAllQueryable(bool deleted = false)
    {
        
        return BehaviorDeleteStatus( Table.AsNoTracking());

        IQueryable<TEntity> BehaviorDeleteStatus(IQueryable<TEntity> entities)
        {
            return deleted ? entities : entities.Where(s => s.Deleted != true);
        }
    }
    
    /// <summary>
    /// Asynchronously retrieves all entities of type TEntity as a list.
    /// </summary>
    /// <param name="deleted">If true, includes entities marked as deleted in the result. Default is false.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all entities of type TEntity.</returns>
    public virtual Task<List<TEntity>> GetAllListAsync(bool deleted = false) =>
        GetAllQueryable(deleted).ToListAsync();
    
    public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate) =>
        GetAllQueryable().Where(predicate).ToListAsync();
    
    public virtual Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate) =>
        GetAllQueryable().FirstOrDefaultAsync(predicate);
    
    public virtual IQueryable<TEntity> FindByQueryable(Expression<Func<TEntity, bool>> predicate) =>
        GetAllQueryable().Where(predicate);
}