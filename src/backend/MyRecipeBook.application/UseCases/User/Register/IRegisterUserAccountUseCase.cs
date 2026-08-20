using MyRecipeBook.communication.Requests;

namespace MyRecipeBook.application.UseCases.User.Register
{
    public interface IRegisterUserAccountUseCase
    {
        void Execute(RequestRegisterUserAccountJson request);
    }
}
