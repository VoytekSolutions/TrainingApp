using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Users;
using Trainings.Infrastructure.Services;

namespace Trainings.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService UserService;

        public CreateUserHandler(IUserService userService)
        {
            UserService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await UserService.RegisterAsync(command.Email, command.UserName, command.Password);
        }
    }
}
