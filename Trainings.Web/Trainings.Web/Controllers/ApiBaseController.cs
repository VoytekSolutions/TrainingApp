using Microsoft.AspNetCore.Mvc;
using Trainings.Infrastructure.Commands;

namespace Trainings.Web.Controllers
{
    [Route("[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiBaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}