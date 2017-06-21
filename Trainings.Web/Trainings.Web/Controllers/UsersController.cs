using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Users;
using Trainings.Infrastructure.Commands.Users;
using Trainings.Infrastructure.Services;
using Trainings.Infrastructure.Settings;

namespace Trainings.Web.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            UserService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await UserService.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}
