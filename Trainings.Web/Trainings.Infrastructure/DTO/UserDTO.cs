using System;
using System.Collections.Generic;
using System.Text;

namespace Trainings.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
