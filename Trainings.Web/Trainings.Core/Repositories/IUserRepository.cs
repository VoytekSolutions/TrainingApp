using System;
using System.Collections.Generic;
using System.Text;
using Trainings.Core.Domain;

namespace Trainings.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(Guid Id);
        User GetUserByEmail(string email);
        ICollection<User> GetUsers();
        void AddUser(User User);
        void UpdateUser(User User);
        void RemoveUser(Guid Id);
    }
}
