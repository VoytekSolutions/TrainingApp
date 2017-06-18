﻿using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands.Users;
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
                .UseStartup<Startup>()
                .UseEnvironment("Development")
                .UseContentRoot("C:\\Projects\\TrainingApp\\Trainings.Web\\Trainings.Web"));

            Client = Server.CreateClient();
        }

        [Fact]
        public async Task GivingValidEmailUserExists()
        {
            // Arrange
            var email = "moj@email.pl";

            //Act
            var user = await GetUserAsync(email);

            // Assert
            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task GivingNotRegisteredEmailUserDoesntExists()
        {
            //Arrange
            var email = "myUnExisting@email.com";

            //Act
            var response = await Client.GetAsync($"users/{email}");
            var status404 = response.StatusCode;

            // Assert
            status404.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivingNewEmailNewUserShouldBeCreated()
        {
            //Arrange
            var request = new CreateUser
            {
                Email = "test@email.com",
                Password = "secret",
                UserName = "NewUserName"
            };

            var payload = GetPayload(request);

            //Act
            var response = await Client.PostAsync("users", payload);

            var user = await GetUserAsync(request.Email);

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");
            //Check Is User created
            user.Email.ShouldBeEquivalentTo(request.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDTO>(responseString);

            return user;
        }

        private StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
