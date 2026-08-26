using CommomTestUtilities.Requests;
using MyRecipeBook.application.UseCases.User.Register;
using Shouldly;
using System.Security.Cryptography.X509Certificates;

namespace Validator.tests.User.Register
{
    public class RegisterUserAccountUseCaseTests
    {
        [Fact]
        public void Success()
        {
            //arrange
            var request = RequestRegisterUserAccountJsonBuilder.Build();
            var validator = new RegisterUserAccountValidator();

            //act

            var result = validator.Validate(request);

            //assert

            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_shouldHaveError_WhenNameIsEmpty()
        {

        }


    }
}
