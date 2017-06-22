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
        private readonly IMapper Mapper;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper)
        {
            TrainerRepository = trainerRepository;
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

            foreach(Trainer trainer in trainersList)
            {
                trainersDtoList.Add(Mapper.Map<Trainer, TrainerDTO>(trainer));
            }

            return trainersDtoList;
        }

        public async Task RegisterAsync(string email, string userName, string password)
        {
            var user = await TrainerRepository.GetTrainerByEmailAsync(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail:{user.Email} already exists.");
            }

            user = new Trainer(email, userName, password);

            await TrainerRepository.AddTrainerAsync(user);
        }
    }
}
