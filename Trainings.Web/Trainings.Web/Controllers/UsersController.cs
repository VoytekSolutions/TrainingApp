using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands.Users;
using Trainings.Infrastructure.DTO;
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
        public async Task<UserDTO> Get(string email)
        {
            return await UserService.GetUserByEmailAsync(email);
        }

        [HttpPost("")]
        public async Task Post([FromBody] CreateUser request)
        {
            await UserService.RegisterAsync(request.Email, request.UserName, request.Password);
        }
    }
}
