using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Persistence.Context;
using AgenticEngineer.Persistence.Repositories;
using Dapper;
using Microsoft.Extensions.DependencyInjection;


namespace AgenticEngineer.Persistence
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new GuidTypeHandler());
            services.AddScoped<DbConnectionFactory>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
