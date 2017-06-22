using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Core.Domain;

namespace Trainings.Core.Repositories
{
    public interface IPupilRepository : IRepository
    {
        Task<Pupil> GetPupilByIdAsync(Guid id);
        Task<Pupil> GetPupilByEmailAsync(string email);
        Task<ICollection<Pupil>> GetPupilsAsync();
        Task AddPupilAsync(Pupil pupil);
        Task UpdatePupilAsync(Pupil pupil);
        Task RemovePupilAsync(Guid id);
    }
}
