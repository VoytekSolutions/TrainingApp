using System.Collections.Generic;

namespace Trainings.Core.Domain
{
    public class Trainer: User
    {
        public Gym Gym { get; protected set; }
        public double Rating { get; protected set; }
        public ICollection<Pupil> Pupils { get; protected set; }
    }
}
