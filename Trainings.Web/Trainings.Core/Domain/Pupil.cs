namespace Trainings.Core.Domain
{
    public class Pupil : User
    {
        public Pupil(string email, string userName, string password) : base(email, userName, password)
        {
        }
    }
}