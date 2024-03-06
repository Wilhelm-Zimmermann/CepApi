using CepApi.Domain.Api.Utils;
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

        // Mysql connection
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

        // Redis cache
        var redisConnectionString = builder.Configuration["RedisConnection:RedisConnectionString"];
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
        });

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // Handlers
        builder.Services.AddScoped<UserHandler, UserHandler>();

        // Utils
        builder.Services.AddScoped<HttpClient, HttpClient>();
        builder.Services.AddScoped<HttpConnection, HttpConnection>();
    }
}
