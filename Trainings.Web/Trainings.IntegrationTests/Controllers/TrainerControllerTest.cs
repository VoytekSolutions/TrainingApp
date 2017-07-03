using Newtonsoft.Json;
using FluentAssertions;
using System.Net;
using System;
using System.Threading.Tasks;
using Trainings.Infrastructure.DTO;
using Xunit;
using Trainings.Infrastructure.Commands.Impl.Trainers;

namespace Trainings.IntegrationTests.Controllers
{
    public class TrainerControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task GivingValidEmailTrainerExists()
        {
            // Arrange
            var email = "mojtrainer@email.pl";

            //Act
            var trainer = await GetTrainerAsync(email);

            // Assert
            trainer.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task GivingNotRegisteredEmailTrainerDoesntExists()
        {
            //Arrange
            var email = "myUnExisting@email.com";

            //Act
            var response = await Client.GetAsync($"trainer/{email}");
            var status404 = response.StatusCode;

            // Assert
            status404.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivingNewEmailNewTrainerShouldBeCreated()
        {
            //Arrange
            var request = new CreateTrainer
            {
                Email = "test@email.com",
                Password = "secret",
                UserName = "NewUserName"
            };

            var payload = GetPayload(request);

            //Act
            var response = await Client.PostAsync("trainer", payload);

            var pupil = await GetTrainerAsync(request.Email);

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"trainer/{request.Email}");
            //Check Is User created
            pupil.Email.ShouldBeEquivalentTo(request.Email);
        }

        private async Task<TrainerDTO> GetTrainerAsync(string email)
        {
            var response = await Client.GetAsync($"trainer/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var trainer = JsonConvert.DeserializeObject<TrainerDTO>(responseString);

            return trainer;
        }
    }
}
