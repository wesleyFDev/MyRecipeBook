using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.domain.Repositories;
using MyRecipeBook.domain.Repositories.User;
using MyRecipeBook.domain.Security.PasswordHasher;
using MyRecipeBook.infrastructure.DataAccess;
using MyRecipeBook.infrastructure.DataAccess.Repositories;
using MyRecipeBook.infrastructure.Security.PasswordHashing;

namespace MyRecipeBook.infrastructure
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataAccess.MyRecipeBookDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                config.UseSqlServer(connectionString);
            });

        }
    }
}
