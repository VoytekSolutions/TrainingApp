using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainings.Core.Domain;

namespace Trainings.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> GetUserByEmailAsync(string email);
        Task<ICollection<User>> GetUsersAsync();
        Task AddUserAsync(User User);
        Task UpdateUserAsync(User User);
        Task RemoveUserAsync(Guid Id);
    }
}
