using CepApi.Domain.Handlers;
using CepApi.Domain.Infra.Context;
using CepApi.Domain.Infra.Repositories;
using CepApi.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CepApi.Domain.Api.Extensions;

public static class DependencyResolver
{
    public static void Resolve(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration["MySqlConnection:MySqlConnectionString"];

        builder.Services.AddDbContext<MySqlContext>(options =>
        {
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 3)),
                mySqlOptions => {
                    mySqlOptions.MigrationsAssembly("CepApi.Domain.Api");
                    mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                });
        });

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // Handlers
        builder.Services.AddScoped<UserHandler, UserHandler>();
    }
}
