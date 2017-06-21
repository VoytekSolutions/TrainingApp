using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Trainers;

namespace Trainings.Web.Controllers
{
    public class TrainerController : ApiBaseController
    {
        public TrainerController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        { }

        [HttpPost("")]
        public async Task<IActionResult> Put([FromBody] CreateTrainer command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
