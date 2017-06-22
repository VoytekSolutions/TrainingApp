﻿using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Trainings.Infrastructure.Commands.Impl.Pupils;
using Xunit;

namespace Trainings.IntegrationTests.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task GivingValidCurrentAndNewPasswordShouldChangePassword()
        {
            //Arrange
            var command = new ChangePupilPassword
            {
                CurrentPassword = "CurrentPass",
                NewPassword = "NewMagicPassword"
            };

            var payload = GetPayload(command);

            //Act
            var response = await Client.PutAsync("account/password", payload);

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}
