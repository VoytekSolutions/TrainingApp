using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trainings.Infrastructure.Services;
using Trainings.Infrastructure.DTO;

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
