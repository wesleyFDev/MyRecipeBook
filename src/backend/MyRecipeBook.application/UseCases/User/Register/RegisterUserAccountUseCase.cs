using MyRecipeBook.communication.Requests;
using MyRecipeBook.exception.ExceptionsBase;

namespace MyRecipeBook.application.UseCases.User.Register
{
    public class RegisterUserAccountUseCase
    {
        public void Execute(RequestRegisterUserAccountJson request)
        {
            var validator = new RegisterUserAccountValidator();

            var result = validator.Validate(request);

            if(!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
