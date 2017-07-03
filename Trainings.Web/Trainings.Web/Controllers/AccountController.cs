using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Pupils;
using Trainings.Infrastructure.Services;

namespace Trainings.Web.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IJwtHandler JwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            JwtHandler = jwtHandler;
        }

        [HttpPut("")]
        [Route("token")]
        public async Task<IActionResult> Get()
        {
            var token = JwtHandler.CreateToken("user1@email.com", "admin");

            return Json(token);
        }

        [HttpPut("")]
        [Authorize]
        [Route("auth")]
        public async Task<IActionResult> GetAuth()
        {
            return Content("Auth");
        }

        [HttpPut("")]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody] ChangePupilPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}