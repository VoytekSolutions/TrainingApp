using System;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands;
using Trainings.Infrastructure.Commands.Impl.Trainers;
using Trainings.Infrastructure.Services;

namespace Trainings.Infrastructure.Handlers.Trainers
{
    public class CreateTrainerHeandler : ICommandHandler<CreateTrainer>
    {
        private readonly ITrainerService TrainerService;
        public CreateTrainerHeandler(ITrainerService trainerService)
        {
            TrainerService = trainerService;
        }

        public async Task HandleAsync(CreateTrainer command)
        {
            await Task.CompletedTask;
        }
    }
}
