using AutoMapper;
using System;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository = userRepository;
            Mapper = mapper;
        }

        public async Task RegisterAsync(string email, string userName, string password)
        {
            var user = await UserRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail:{user.Email} already exists.");
            }

            user = new User(email, userName, password);

            await UserRepository.AddUserAsync(user);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await UserRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail:{user.Email} doesn't exists.");
            }

            return Mapper.Map<User, UserDTO>(user);
        }
    }
}
