using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public void AddUser(User User)
        {
            _users.Add(User);
        }

        public User GetUserByEmail(string email)
        {
            return _users.Single(user => user.Email == email.ToLowerInvariant());
        }

        public User GetUserById(Guid Id)
        {
            return _users.Single(user => user.UserId == Id);
        }

        public ICollection<User> GetUsers()
        {
            return _users.ToList();
        }

        public void RemoveUser(Guid Id)
        {
            var user = GetUserById(Id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public void UpdateUser(User User)
        {
            var user = GetUserById(User.UserId);

            if (user != null)
            {
                user.UpdateData(User);
            }
        }
    }
}
