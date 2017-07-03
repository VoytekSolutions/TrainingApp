using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(string email, string role);
    }
}
