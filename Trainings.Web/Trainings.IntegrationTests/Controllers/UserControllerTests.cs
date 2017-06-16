using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Trainings.Infrastructure.DTO;
using Trainings.Web;
using Xunit;

namespace Trainings.IntegrationTests.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer Server;
        private readonly HttpClient Client;

        public UserControllerTests()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

     
            Client = Server.CreateClient();
        }

        [Fact]
        public async Task GiveingValidEmailUserExists()
        {
            // Act
            var email = "moj@email.pl";

            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDTO>(responseString);

            // Assert
            user.Email.ShouldBeEquivalentTo(email);
        }
    }
}
