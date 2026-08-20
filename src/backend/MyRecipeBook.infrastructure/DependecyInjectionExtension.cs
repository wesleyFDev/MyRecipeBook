using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.domain.Security.PasswordHasher;
using MyRecipeBook.infrastructure.Security.PasswordHashing;

namespace MyRecipeBook.infrastructure
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
           
        }
    }
}
