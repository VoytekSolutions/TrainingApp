using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Pupils;

namespace Trainings.Infrastructure.Handlers.Users
{
    public class ChangePupilPasswordHandler : ICommandHandler<ChangePupilPassword>
    {
        public async Task HandleAsync(ChangePupilPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
