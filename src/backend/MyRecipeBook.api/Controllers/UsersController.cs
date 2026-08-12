using Microsoft.AspNetCore.Mvc;

namespace MyRecipeBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IActionResult Register()
        {
            // Implement user registration logic here
            return Created();
        }
    }
}
