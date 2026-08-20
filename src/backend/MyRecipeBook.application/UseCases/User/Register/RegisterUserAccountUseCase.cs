using Mapster;
using MyRecipeBook.communication.Requests;
using MyRecipeBook.domain.Entities;
using MyRecipeBook.domain.Extensions;
using MyRecipeBook.domain.Security.PasswordHasher;
using MyRecipeBook.exception.ExceptionsBase;
using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.application.UseCases.User.Register
{
    
    public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
    {
        private readonly IPasswordHasher _passwordHasher;
        public RegisterUserAccountUseCase(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Execute(RequestRegisterUserAccountJson request)
        {

       

            ValidateAndThrowFailures(request);
            var user = request.Adapt<domain.Entities.User>();

            user.Password = _passwordHasher.HashPassword(request.Password);
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
