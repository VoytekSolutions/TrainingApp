using System;
using System.Collections.Generic;
using System.Linq;

namespace Trainings.Core.Domain
{
    public class Trainer : User
    {
        private ISet<Pupil> _pupils = new HashSet<Pupil>();

        public Gym Gym { get; protected set; }
        public double Rating { get; protected set; }
        public ISet<Pupil> Pupils => _pupils;

        protected Trainer() {}

        public Trainer(string email, string userName, string password, string salt)
        {
            UserId = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            UserName = UserName;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

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
            _pupils.Add(newPupil);
        }

        public void RemovePupil(Pupil pupil)
        {
            var pupilToRemove = _pupils.SingleOrDefault(x => x.Email == pupil.Email);

            if (pupilToRemove == null)
            {
                return;
            }

            _pupils.Remove(pupilToRemove);
        }

        public void UpdateData(Trainer trainer)
        {
            Email = trainer.Email;
            FirstName = trainer.FirstName;
            Password = trainer.Password;
            SecondName = trainer.SecondName;
            UserName = trainer.UserName;
            Gym = trainer.Gym;
            Rating = trainer.Rating;
            _pupils = trainer.Pupils;
        }
    }
}
