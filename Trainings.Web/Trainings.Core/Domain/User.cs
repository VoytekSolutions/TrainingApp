using System;

namespace Trainings.Core.Domain
{
    public class User
    {
        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string userName, string password)
        {
            UserId = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            UserName = UserName;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateData(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            Password = user.Password;
            SecondName = user.SecondName;
            UserName = user.UserName;
        }
    }
}
