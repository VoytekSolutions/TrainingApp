using AutoMapper;
using System;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.DTO;
using System.Collections.Generic;

namespace Trainings.Infrastructure.Services.Impl
{
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository PupilRepository;
        private readonly IMapper Mapper;

        public PupilService(IPupilRepository pupilRepository, IMapper mapper)
        {
            PupilRepository = pupilRepository;
            Mapper = mapper;
        }

        public async Task RegisterAsync(string email, string userName, string password)
        {
            var user = await PupilRepository.GetPupilByEmailAsync(email);

            if (user != null)
            {
                throw new Exception($"Pupil with e-mail:{user.Email} already exists.");
            }

            user = new Pupil(email, userName, password);

            await PupilRepository.AddPupilAsync(user);
        }

        public async Task<PupilDTO> GetPupilByEmailAsync(string email)
        {
            var user = await PupilRepository.GetPupilByEmailAsync(email);

            return Mapper.Map<Pupil, PupilDTO>(user);
        }

        public async Task<ISet<PupilDTO>> GetPupils()
        {
            var pupilsList = await PupilRepository.GetPupilsAsync();

            ISet<PupilDTO> pupilsDtoList = new HashSet<PupilDTO>();

            foreach (Pupil pupil in pupilsList)
            {
                pupilsDtoList.Add(Mapper.Map<Pupil, PupilDTO>(pupil));
            }

            return pupilsDtoList;
        }
    }
}
