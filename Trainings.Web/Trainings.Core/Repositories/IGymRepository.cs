using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trainings.Core.Domain;

namespace Trainings.Core.Repositories
{
    public interface IGymRepository : IRepository
    {
        Task<Gym> GetGymByIdAsync(Guid id);
        Task<Gym> GetGymByEmailAsync(string email);
        Task<ICollection<Gym>> GetGymsAsync();
        Task AddGymAsync(Gym gym);
        Task UpdateGymAsync(Gym gym);
        Task RemoveGymAsync(Guid id);
    }
}
