using System.Collections.Generic;

namespace Trainings.Core.Domain
{
    public class Trainer : User
    {
        public Gym Gym { get; protected set; }
        public double Rating { get; protected set; }
        public ISet<Pupil> Pupils { get; protected set; }

        public void SetRating(double rating)
        {
            Rating = rating;
        }

        public void SetGym(Gym gym)
        {
            Gym = gym;
        }

        public void AddPupil(Pupil newPupil)
        {
            if (Pupils == null)
            {
                Pupils = new HashSet<Pupil>();
            }

            Pupils.Add(newPupil);
        }
    }
}
