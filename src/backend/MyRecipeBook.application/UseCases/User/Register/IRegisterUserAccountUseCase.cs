using MyRecipeBook.communication.Requests;
using MyRecipeBook.communication.Responses;

namespace MyRecipeBook.application.UseCases.User.Register
{
    public interface IRegisterUserAccountUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request);
    }
}
