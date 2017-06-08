using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface IUserService
    {
        void Register(string email, string userName, string password);
        UserDTO GetUserByEmail(string email);
    }
}
