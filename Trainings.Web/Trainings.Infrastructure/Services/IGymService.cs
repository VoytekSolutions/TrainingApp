using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface IGymService : IService
    {
        Task RegisterAsync(string name, string email, Position position);
        Task<GymDTO> GetGymByEmailAsync(string email);
    }
}
