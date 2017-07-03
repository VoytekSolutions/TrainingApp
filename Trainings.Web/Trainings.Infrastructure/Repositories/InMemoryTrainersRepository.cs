using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;

namespace Trainings.Infrastructure.Repositories
{
    public class InMemoryTrainersRepository : ITrainerRepository
    {
        private static ISet<Trainer> _trainers = new HashSet<Trainer>()
        {
            new Trainer("mojtrainer@email.pl","UserName","Password","salt"),
            new Trainer("twojtrainer@email.pl","UserName2","Mordo","salt"),
            new Trainer("azajktrainer@email.pl","UserName3","tajne","salt"),
            new Trainer("siematrainer@email.pl","UserName4","Elo","salt")
        };

        public async Task AddTrainerAsync(Trainer trainer)
        {
            await Task.FromResult(_trainers.Add(trainer));
        }

        public async Task<Trainer> GetTrainerByEmailAsync(string email)
        {
            return await Task.FromResult(_trainers.SingleOrDefault(trainer => trainer.Email == email.ToLowerInvariant()));
        }

        public async Task<Trainer> GetTrainerByIdAsync(Guid id)
        {
            return await Task.FromResult(_trainers.SingleOrDefault(trainer => trainer.UserId == id));
        }

        public async Task<ICollection<Trainer>> GetTrainersAsync()
        {
            return await Task.FromResult(_trainers.ToList());
        }

        public async Task RemoveTrainerAsync(Guid id)
        {
            var trainer = await GetTrainerByIdAsync(id);
            if (trainer != null)
            {
                _trainers.Remove(trainer);
                await Task.CompletedTask;
            }
        }

        public async Task UpdateTrainerAsync(Trainer trainer)
        {
            var currentTrainer = await GetTrainerByIdAsync(trainer.UserId);

            if (currentTrainer != null)
            {
                currentTrainer.UpdateData(trainer);
                await Task.CompletedTask;
            }
        }
    }
}
