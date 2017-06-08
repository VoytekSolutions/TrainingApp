using System;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Register(string email, string userName, string password)
        {
            var user = UserRepository.GetUserByEmail(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail:{user.Email} already exists.");
            }

            user = new User(email, userName, password);

            UserRepository.AddUser(user);
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = UserRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail:{user.Email} doesn't exists.");
            }

            return new UserDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                UserId = user.UserId,
                UserName = user.UserName
            };
        }
    }
}
