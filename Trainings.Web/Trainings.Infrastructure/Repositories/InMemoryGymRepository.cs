using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;

namespace Trainings.Infrastructure.Repositories
{
    public class InMemoryGymRepository : IGymRepository
    {
        private static ISet<Gym> _gyms = new HashSet<Gym>()
        {
            Gym.Create("PureJatomi", "pure@jatomi.com", Position.Create("Supersam",1.0,1.0)),
            Gym.Create("CitiFit", "city@fit.pl", Position.Create("Rynek",1.0,1.0)),
            Gym.Create("FitnessPoint","fitness@point.pl", Position.Create("3Stawy",1.0,1.0))
        };

        public async Task AddGymAsync(Gym gym)
        {
            await Task.FromResult(_gyms.Add(gym));
        }

        public async Task<Gym> GetGymByEmailAsync(string email)
        {
            return await Task.FromResult(_gyms.SingleOrDefault(gym => gym.Email == email));
        }

        public async Task<Gym> GetGymByIdAsync(Guid id)
        {
            return await Task.FromResult(_gyms.SingleOrDefault(gym => gym.GymId == id));
        }

        public async Task<ICollection<Gym>> GetGymsAsync()
        {
            return await Task.FromResult(_gyms.ToList());
        }

        public async Task RemoveGymAsync(Guid id)
        {
            var gym = await GetGymByIdAsync(id);
            if (gym != null)
            {
                await Task.FromResult(_gyms.Remove(gym));
            }
        }

        public async Task UpdateGymAsync(Gym Gym)
        {
            var currentGym = await GetGymByIdAsync(Gym.GymId);

            if (currentGym != null)
            {
                currentGym.UpdateData(Gym);
                await Task.CompletedTask;
            }
        }
    }
}
