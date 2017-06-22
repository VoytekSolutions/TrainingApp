using System;

namespace Trainings.Infrastructure.DTO
{
    public class PupilDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
