using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Repository.Concretes.Cqrs;
using DrMW.Cqrs.Repository.Concretes.SystemRepos;
using DrMW.Cqrs.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrMW.Cqrs.Repository;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services,IConfiguration configuration)
    {
        if (services == null) throw new AggregateException("service is null");

        services.AddDbContext<AppDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddDbContext<AppSelectDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
        
        services.AddScoped<ISelectRepositories, SelectRepositories>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    } 
}