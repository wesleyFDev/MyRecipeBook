using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.application.UseCases.User.Register;
using MyRecipeBook.communication.Requests;

namespace MyRecipeBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RequestRegisterUserAccountJson request)
        {
            var useCase = new RegisterUserAccountUseCase();
           
            useCase.Execute(request);
            return Created();
        }
    }
}
