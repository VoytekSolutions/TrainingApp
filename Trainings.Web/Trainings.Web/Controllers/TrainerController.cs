using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Trainers;
using Trainings.Infrastructure.Services;

namespace Trainings.Web.Controllers
{
    public class TrainerController : ApiBaseController
    {
        private readonly ITrainerService TrainerService;

        public TrainerController(ITrainerService trainerService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            TrainerService = trainerService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Put([FromBody] CreateTrainer command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"trainer/{command.Email}", new object());
        }

        [HttpGet("{email}")]
        [Route("getTrainerByEmail")]
        public async Task<IActionResult> Get(string email)
        {
            var trainer = await TrainerService.GetTrainerByEmailAsync(email);

            if (trainer == null)
            {
                return NotFound();
            }

            return Json(trainer);
        }

        [HttpGet("")]
        [Route("getTrainers")]
        public async Task<IActionResult> Get()
        {
            var trainers = await TrainerService.GetTrainers();

            return Json(trainers);
        }
    }
}
