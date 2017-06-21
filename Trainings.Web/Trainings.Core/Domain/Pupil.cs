namespace Trainings.Core.Domain
{
    public class Pupil : User
    {
        protected Pupil() { }

        protected Pupil(string email, string userName, string password) : base(email, userName, password)
        {
        }

        public static Pupil Create(string email, string userName, string password)
            => new Pupil(email, userName, password);
    }
}