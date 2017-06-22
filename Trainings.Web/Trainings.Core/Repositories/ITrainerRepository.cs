using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Core.Domain;

namespace Trainings.Core.Repositories
{
    public interface ITrainerRepository : IRepository
    {
        Task<Trainer> GetTrainerByIdAsync(Guid id);
        Task<Trainer> GetTrainerByEmailAsync(string email);
        Task<ICollection<Trainer>> GetTrainersAsync();
        Task AddTrainerAsync(Trainer trainer);
        Task UpdateTrainerAsync(Trainer trainer);
        Task RemoveTrainerAsync(Guid id);
    }
}
