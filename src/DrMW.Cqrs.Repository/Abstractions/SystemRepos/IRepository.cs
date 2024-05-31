using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Abstractions.SystemRepos;

public interface IRepository<TEntity> : IDisposable
    where TEntity : class
{
    DbSet<TEntity> Table { get; }
}