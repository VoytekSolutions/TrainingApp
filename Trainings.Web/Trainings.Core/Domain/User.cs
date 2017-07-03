using System;
using System.ComponentModel.DataAnnotations;

namespace Trainings.Core.Domain
{
    public class User
    {
        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User() { }

        protected User(string email, string userName, string password, string salt)
        {
            UserId = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            UserName = UserName;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            var emailValidator = new EmailAddressAttribute();

            if (emailValidator.IsValid(email))
            {
                Email = email;
            }
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetSecondName(string secondName)
        {
            SecondName = secondName;
        }
    }
}
