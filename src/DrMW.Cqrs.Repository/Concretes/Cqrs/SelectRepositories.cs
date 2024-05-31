using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Repository.Concretes.SystemRepos;
using DrMW.Cqrs.Repository.Data;

namespace DrMW.Cqrs.Repository.Concretes.Cqrs;

public class SelectRepositories : ISelectRepositories
{
    protected readonly AppSelectDb DbContext;
    protected readonly Dictionary<Type, object> Repositories;
    
    /// <summary>
    /// Constructor for QueryRepositories.
    /// </summary>
    /// <param name="context">The DbContext to be used for queries.</param>
    public SelectRepositories(AppSelectDb context)
    {
        DbContext = context;
        Repositories = new Dictionary<Type, object>();
    }
    
    /// <summary>
    /// Gets a repository for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TPrimary">The primary key type.</typeparam>
    /// <returns>An instance of the read repository for the specified entity type.</returns>
    public virtual IReadRepository<TEntity, TPrimary> Repository<TEntity, TPrimary>()
        where TEntity : class, IBaseEntity<TPrimary>, new()
    {
        if (Repositories.Keys.Contains(typeof(TEntity)))
            return Repositories[typeof(TEntity)] as IReadRepository<TEntity, TPrimary>;

        var repo = new ReadRepository<TEntity, TPrimary>(DbContext);
        Repositories.Add(typeof(TEntity), repo);
        return repo;
    }
    
    /// <summary>
    /// Gets a special repository based on the provided type.
    /// </summary>
    /// <typeparam name="TRepository">The type of the special repository.</typeparam>
    /// <returns>An instance of the special repository.</returns>
    public virtual TRepository SpecialRepository<TRepository>()
    {
        if (Repositories.Keys.Contains(typeof(TRepository)))
            return (TRepository)Repositories[typeof(TRepository)];

        var type = typeof(AppSelectDb).Assembly.GetTypes()
            .FirstOrDefault(x => !x.IsAbstract
                                 && !x.IsInterface
                                 && x.Name == typeof(TRepository).Name.Substring(1));

        if (type == null)
            throw new KeyNotFoundException($"Repository type is not found: {typeof(TRepository).Name.Substring(1)}");

        var repository = (TRepository)Activator.CreateInstance(type, DbContext)!;
        Repositories.Add(typeof(TRepository), repository);
        return repository;
    }
   
    /// <summary>
    /// Disposes of the DbContext and clears repository references.
    /// </summary>
    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes of resources.
    /// </summary>
    /// <param name="disposing">True if disposing; otherwise, false.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose of DbContext
            DbContext?.Dispose();

            // Dispose of repositories that implement IDisposable
            foreach (var repository in Repositories.Values)
            {
                if (repository is IDisposable disposableRepo)
                {
                    disposableRepo.Dispose();
                }
            }

            Repositories.Clear();
        }
    }

    /// <summary>
    /// Finalizer to ensure Dispose is called.
    /// </summary>
    ~SelectRepositories()
    {
        Dispose(false);
    }
}