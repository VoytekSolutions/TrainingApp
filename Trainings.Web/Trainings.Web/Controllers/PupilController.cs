using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Pupils;
using Trainings.Infrastructure.Services;

namespace Trainings.Web.Controllers
{
    public class PupilController : ApiBaseController
    {
        private readonly IPupilService PupilService;

        public PupilController(IPupilService pupilService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            PupilService = pupilService;
        }

        [HttpGet("{email}")]
        [Route("getPupilByEmail")]
        public async Task<IActionResult> Get(string email)
        {
            var pupil = await PupilService.GetPupilByEmailAsync(email);

            if (pupil == null)
            {
                return NotFound();
            }

            return Json(pupil);
        }

        [HttpGet("")]
        [Route("getPupils")]
        public async Task<IActionResult> Get()
        {
            var pupils = await PupilService.GetPupils();

            return Json(pupils);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreatePupil command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"pupil/{command.Email}", new object());
        }
    }
}
