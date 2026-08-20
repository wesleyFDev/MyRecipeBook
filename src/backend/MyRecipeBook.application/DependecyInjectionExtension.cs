using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.application.UseCases.User.Register;

namespace MyRecipeBook.application
{
    public static class DependecyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserAccountUseCase ,RegisterUserAccountUseCase>();
        }
    }
}
