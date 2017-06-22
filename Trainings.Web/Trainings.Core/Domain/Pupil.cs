using System;

namespace Trainings.Core.Domain
{
    public class Pupil : User
    {
        public Trainer Trainer { get; protected set; }

        protected Pupil() { }

        public Pupil(string email, string userName, string password) : base(email, userName, password)
        {
        }

        public void SetTrainer(Trainer trainer)
        {
            Trainer = trainer;
        }

        public void UpdateData(Pupil pupil)
        {
            Email = pupil.Email;
            FirstName = pupil.FirstName;
            Password = pupil.Password;
            SecondName = pupil.SecondName;
            UserName = pupil.UserName;
            Trainer = pupil.Trainer;
        }
    }
}