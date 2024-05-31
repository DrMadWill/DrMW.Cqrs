using System.Linq.Expressions;
using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Repository.Abstractions.SystemRepos;

public interface IReadRepository<TEntity, in TPrimaryKey> : IRepository<TEntity>
    where TEntity : class, IOriginEntity<TPrimaryKey>
{
    IQueryable<TEntity> GetAllQueryable(bool deleted = false);


    /// <summary>
    /// Asynchronously retrieves all entities of type TEntity as a list.
    /// </summary>
    /// <param name="deleted">If true, includes entities marked as deleted in the result. Default is false.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all entities of type TEntity.</returns>
    Task<List<TEntity>> GetAllListAsync(bool deleted = false);

    Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> FindByQueryable(Expression<Func<TEntity, bool>> predicate);

}