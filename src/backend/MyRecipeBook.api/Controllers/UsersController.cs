using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.application.UseCases.User.Register;
using MyRecipeBook.communication.Requests;

namespace MyRecipeBook.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase userCase)
        {
            userCase.Execute(request);

            return Created();
        }
    }
}
