using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Pupils;
using Trainings.Infrastructure.Services;

namespace Trainings.Infrastructure.Handlers.Users
{
    public class CreatePupilHandler : ICommandHandler<CreatePupil>
    {
        private readonly IPupilService PupilService;

        public CreatePupilHandler(IPupilService pupilService)
        {
            PupilService = pupilService;
        }

        public async Task HandleAsync(CreatePupil command)
        {
            await PupilService.RegisterAsync(command.Email, command.UserName, command.Password);
        }
    }
}
