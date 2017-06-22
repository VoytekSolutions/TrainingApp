namespace Trainings.Infrastructure.Commands.Impl.Pupils
{
    public class CreatePupil : ICommand
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
