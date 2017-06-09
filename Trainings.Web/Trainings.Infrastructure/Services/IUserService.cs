﻿using System.Threading.Tasks;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string userName, string password);
        Task<UserDTO> GetUserByEmailAsync(string email);
    }
}
