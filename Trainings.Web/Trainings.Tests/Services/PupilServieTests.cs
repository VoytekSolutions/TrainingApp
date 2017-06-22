using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Trainings.Core.Domain;
using Trainings.Core.Repositories;
using Trainings.Infrastructure.Services.Impl;
using Xunit;

namespace Trainings.Tests.Services
{
    public class PupilServieTests
    {
        [Fact]
        public async Task RegisterAsyncShouldInvokeAsyncOnRepository()
        {
            var pupilRepositoryMock = new Mock<IPupilRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new PupilService(pupilRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("new.email@best.com", "UserName", "SecretPass");

            pupilRepositoryMock.Verify(x => x.AddPupilAsync(It.IsAny<Pupil>()), Times.Once);
        }
    }
}
