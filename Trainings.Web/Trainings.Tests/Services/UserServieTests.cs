using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.Services.Impl;
using Xunit;

namespace Trainings.Tests.Services
{
    public class UserServieTests
    {
        [Fact]
        public async Task RegisterAsyncShouldInvokeAsyncOnRepository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("new.email@best.com", "UserName", "SecretPass");

            userRepositoryMock.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
