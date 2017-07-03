using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services.Impl
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository TrainerRepository;
        private readonly IEncrypter Encrypter;
        private readonly IMapper Mapper;

        public TrainerService(ITrainerRepository trainerRepository, IEncrypter encrypter, IMapper mapper)
        {
            TrainerRepository = trainerRepository;
            Encrypter = encrypter;
            Mapper = mapper;
        }

        public async Task<TrainerDTO> GetTrainerByEmailAsync(string email)
        {
            var trainer = await TrainerRepository.GetTrainerByEmailAsync(email);

            return Mapper.Map<Trainer, TrainerDTO>(trainer);
        }

        public async Task<ISet<TrainerDTO>> GetTrainers()
        {
            var trainersList = await TrainerRepository.GetTrainersAsync();

            ISet<TrainerDTO> trainersDtoList = new HashSet<TrainerDTO>();

            foreach (Trainer trainer in trainersList)
            {
                trainersDtoList.Add(Mapper.Map<Trainer, TrainerDTO>(trainer));
            }

            return trainersDtoList;
        }

        public async Task LoginAsync(string email, string password)
        {
            var trainer = await TrainerRepository.GetTrainerByEmailAsync(email);

            if (trainer != null)
            {
                throw new Exception($"Invalid cridentials.");
            }

            var salt = Encrypter.GetSalt(password);
            var hash = Encrypter.GetHash(password, salt);

            if (trainer.Password == hash)
            {
                return;
            }

            throw new Exception($"Invalid cridentials");
        }

        public async Task RegisterAsync(string email, string userName, string password)
        {
            var trainer = await TrainerRepository.GetTrainerByEmailAsync(email);

            if (trainer != null)
            {
                throw new Exception($"User with e-mail:{trainer.Email} already exists.");
            }

            var salt = Encrypter.GetSalt(password);
            var hash = Encrypter.GetHash(password, salt);

            trainer = new Trainer(email, userName, hash, salt);

            await TrainerRepository.AddTrainerAsync(trainer);
        }
    }
}
