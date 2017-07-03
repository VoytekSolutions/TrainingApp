using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;

namespace Trainings.Infrastructure.Repositories
{
    public class InMemoryPupilRepository : IPupilRepository
    {
        private static ISet<Pupil> _pupils = new HashSet<Pupil>()
        {
            new Pupil("moj@email.pl","UserName","Password","salt"),
            new Pupil("twoj@email.pl","UserName2","Mordo","salt"),
            new Pupil("azajk@email.pl","UserName3","tajne","salt"),
            new Pupil("siema@email.pl","UserName4","Elo","salt")
        };

        public async Task AddPupilAsync(Pupil pupil)
        {
            await Task.FromResult(_pupils.Add(pupil));
        }

        public async Task<Pupil> GetPupilByEmailAsync(string email)
        {
            return await Task.FromResult(_pupils.SingleOrDefault(pupil => pupil.Email == email.ToLowerInvariant()));
        }

        public async Task<Pupil> GetPupilByIdAsync(Guid id)
        {
            return await Task.FromResult(_pupils.SingleOrDefault(pupil => pupil.UserId == id));
        }

        public async Task<ICollection<Pupil>> GetPupilsAsync()
        {
            return await Task.FromResult(_pupils.ToList());
        }

        public async Task RemovePupilAsync(Guid id)
        {
            var pupil = await GetPupilByIdAsync(id);
            if (pupil != null)
            {
                _pupils.Remove(pupil);
                await Task.CompletedTask;
            }
        }

        public async Task UpdatePupilAsync(Pupil pupil)
        {
            var currentPupil = await GetPupilByIdAsync(pupil.UserId);

            if (currentPupil != null)
            {
                currentPupil.UpdateData(pupil);
                await Task.CompletedTask;
            }
        }
    }
}
