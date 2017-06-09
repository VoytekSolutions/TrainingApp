using AutoMapper;
using System;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services.Impl
{
    public class GymService : IGymService
    {
        private readonly IGymRepository GymRepository;
        private readonly IMapper Mapper;

        public GymService(IGymRepository gymRepository, IMapper mapper)
        {
            GymRepository = gymRepository;
            Mapper = mapper;
        }

        public async Task<GymDTO> GetGymByEmailAsync(string email)
        {
            var gym = await GymRepository.GetGymByEmailAsync(email);

            if (gym == null)
            {
                throw new Exception($"Gym with e-mail:{gym.Email} doesn't exists.");
            }

            return Mapper.Map<Gym, GymDTO>(gym);
        }

        public async Task RegisterAsync(string name, string email, Position position)
        {
            var gym = await GymRepository.GetGymByEmailAsync(email);

            if (gym != null)
            {
                throw new Exception($"Gym with e-mail:{gym.Email} already exists.");
            }

            gym = new Gym(name, email, position);

            await GymRepository.AddGymAsync(gym);
        }
    }
}
