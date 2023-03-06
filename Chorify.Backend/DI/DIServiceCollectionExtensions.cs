using Chorify.Backend.Services.Implementations;
using Chorify.Backend.Services.Interfaces;
using Chorify.Domain.Commands;
using Chorify.Domain.Queries;
using Chorify.EntityFramework;
using Chorify.EntityFramework.Commands;
using Chorify.EntityFramework.Queries;
using Chorify.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chorify.Backend.DI
{
    public static class DIServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, WebApplicationBuilder context)
        {
            var connectionString = context.Configuration.GetConnectionString("sqlite");

            services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            services.AddSingleton<ChorifyDbContextFactory>();

            return services;
        }

        public static IServiceCollection AddCommandGroup(this IServiceCollection services)
        {
            services.AddScoped<ICreateChoreCommand, CreateChoreCommand>();
            services.AddScoped<IDeleteChoreCommand, DeleteChoreCommand>();
            services.AddScoped<IUpdateChoreCommand, UpdateChoreCommand>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();

            return services;
        }

        public static IServiceCollection AddQueryGroup(this IServiceCollection services)
        {
            services.AddScoped<IGetAllChoresQuery, GetAllChoresQuery>();
            services.AddScoped<IGetUserQuery, GetUserQuery>();

            return services;
        }

        public static IServiceCollection AddServiceGroup(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChoreService, ChoreService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
