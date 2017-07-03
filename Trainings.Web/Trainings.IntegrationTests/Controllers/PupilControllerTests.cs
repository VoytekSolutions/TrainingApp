using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands.Impl.Pupils;
using Trainings.Infrastructure.DTO;
using Xunit;

namespace Trainings.IntegrationTests.Controllers
{
    public class PupilControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task GivingValidEmailPupilExists()
        {
            // Arrange
            var email = "moj@email.pl";

            //Act
            var pupil = await GetPupilAsync(email);

            // Assert
            pupil.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task GivingNotRegisteredEmailPupilDoesntExists()
        {
            //Arrange
            var email = "myUnExisting@email.com";

            //Act
            var response = await Client.GetAsync($"pupil/{email}");
            var status404 = response.StatusCode;

            // Assert
            status404.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivingNewEmailNewPupilShouldBeCreated()
        {
            //Arrange
            var request = new CreatePupil
            {
                Email = "test@email.com",
                Password = "secret",
                UserName = "NewUserName"
            };

            var payload = GetPayload(request);

            //Act
            var response = await Client.PostAsync("pupil", payload);

            var pupil = await GetPupilAsync(request.Email);

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"pupil/{request.Email}");
            //Check Is User created
            pupil.Email.ShouldBeEquivalentTo(request.Email);
        }

        private async Task<PupilDTO> GetPupilAsync(string email)
        {
            var response = await Client.GetAsync($"pupil/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var pupil = JsonConvert.DeserializeObject<PupilDTO>(responseString);

            return pupil;
        }
    }
}
