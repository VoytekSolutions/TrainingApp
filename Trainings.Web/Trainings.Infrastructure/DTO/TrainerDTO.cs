using System;
using System.Collections.Generic;
using System.Text;
using Trainings.Core.Domain;

namespace Trainings.Infrastructure.DTO
{
    public class TrainerDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Gym Gym { get; set; }
        public double Rating { get; set; }
        public ISet<Pupil> Pupils { get; set; }
    }
}
