using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;

namespace DrMW.Cqrs.Repository.Abstractions.Cqrs;

public interface ISelectRepositories : IDisposable
{
    /// <summary>
    /// Gets a repository for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TPrimary">The primary key type.</typeparam>
    /// <returns>An instance of the read repository for the specified entity type.</returns>
    IReadRepository<TEntity, TPrimary> Repository<TEntity, TPrimary>()
        where TEntity : class, IBaseEntity<TPrimary>, new();
   
    /// <summary>
    /// Gets a special repository based on the provided type.
    /// </summary>
    /// <typeparam name="TRepository">The type of the special repository.</typeparam>
    /// <returns>An instance of the special repository.</returns>
    TRepository SpecialRepository<TRepository>(); 
}