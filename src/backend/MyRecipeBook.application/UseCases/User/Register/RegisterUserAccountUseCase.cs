using Mapster;
using MyRecipeBook.communication.Requests;
using MyRecipeBook.domain.Entities;
using MyRecipeBook.exception.ExceptionsBase;
using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.application.UseCases.User.Register
{
    public class RegisterUserAccountUseCase
    {
        public void Execute(RequestRegisterUserAccountJson request)
        {
            ValidateAndThrowFailures(request);
            var user = request.Adapt<domain.Entities.User>();
        }



        private void ValidateAndThrowFailures(RequestRegisterUserAccountJson request)
        {
            var validator = new RegisterUserAccountValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
