namespace Trainings.Infrastructure.Commands.Impl.Pupils
{
    public class ChangePupilPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
