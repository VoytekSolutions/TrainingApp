using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface IPupilService : IService
    {
        Task RegisterAsync(string email, string userName, string password);
        Task LoginAsync(string email, string password);
        Task<PupilDTO> GetPupilByEmailAsync(string email);
        Task<ISet<PupilDTO>> GetPupils();
    }
}
