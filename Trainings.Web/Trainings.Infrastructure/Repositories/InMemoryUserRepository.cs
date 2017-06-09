using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;

namespace Trainings.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("moj@email.pl","UserName","Password"),
            new User("twoj@email.pl","UserName2","Mordo"),
            new User("azajk@email.pl","UserName3","tajne"),
            new User("siema@email.pl","UserName4","Elo")
        };

        public async Task AddUserAsync(User user)
        {
            await Task.FromResult(_users.Add(user));
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Email == email.ToLowerInvariant()));
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.UserId == id));
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await Task.FromResult(_users.ToList());
        }

        public async Task RemoveUserAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _users.Remove(user);
                await Task.CompletedTask;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            var currentUser = await GetUserByIdAsync(user.UserId);

            if (currentUser != null)
            {
                currentUser.UpdateData(user);
                await Task.CompletedTask;
            }
        }
    }
}
