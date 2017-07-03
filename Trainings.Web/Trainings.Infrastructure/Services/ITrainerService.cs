using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface ITrainerService : IService
    {
        Task RegisterAsync(string email, string userName, string password);
        Task LoginAsync(string email, string password);
        Task<TrainerDTO> GetTrainerByEmailAsync(string email);
        Task<ISet<TrainerDTO>> GetTrainers();
    }
}
