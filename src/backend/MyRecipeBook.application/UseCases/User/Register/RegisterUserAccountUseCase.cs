using FluentValidation.Results;
using Mapster;
using MyRecipeBook.communication.Requests;
using MyRecipeBook.communication.Responses;
using MyRecipeBook.domain.Entities;
using MyRecipeBook.domain.Extensions;
using MyRecipeBook.domain.Repositories;
using MyRecipeBook.domain.Repositories.User;
using MyRecipeBook.domain.Security.PasswordHasher;
using MyRecipeBook.exception;
using MyRecipeBook.exception.ExceptionsBase;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MyRecipeBook.application.UseCases.User.Register
{

    public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserAccountUseCase(
            IPasswordHasher passwordHasher,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUnitOfWork unitOfWork)

        {
            _passwordHasher = passwordHasher;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request)
        {
            await ValidateAndThrowFailures(request);
            var user = request.Adapt<domain.Entities.User>();

            user.Password = _passwordHasher.HashPassword(request.Password);
            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,

            };
        }



        private async Task ValidateAndThrowFailures(RequestRegisterUserAccountJson request)
        {
            var validator = new RegisterUserAccountValidator();

            var result = validator.Validate(request);
            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email!);
            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessageException.VALIDATION_EMAIL_ALREADY_EXIST));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
