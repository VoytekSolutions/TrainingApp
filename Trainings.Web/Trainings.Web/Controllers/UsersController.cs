using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands.Users;
using Trainings.Infrastructure.Services;

namespace Trainings.Web.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await UserService.GetUserByEmailAsync(email);

            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser request)
        {
            await UserService.RegisterAsync(request.Email, request.UserName, request.Password);

            return Created($"users/{request.Email}", new object());
        }
    }
}
