using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Users;
using Trainings.Infrastructure.Services;

namespace Trainings.Web.Controllers
{
    public class AccountController : ApiBaseController
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {}

        [HttpPut("")]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}