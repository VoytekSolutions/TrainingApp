using Microsoft.AspNetCore.Mvc;
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
        public UserDTO Get(string email)
        {
            return UserService.GetUserByEmail(email);
        }
    }
}
