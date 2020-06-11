using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business;
using UserManagement.Business.Helpers;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Tests
{
    public class StoryTests
    {
        private readonly Mock<ILoggingWork> LoggingWork;
        private readonly Mock<IReportingWork> ReportingWork;
        private readonly IUser Story;
        private readonly Faker Faker;
        private readonly UserModel UserModel;
        private readonly List<UserModel> UserModels;

        public StoryTests()
        {
            Faker = new Faker();

            UserModel = new UserModel
            {
                Id = Faker.Random.Guid(),
                Email = Faker.Internet.Email(),
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
            };
            UserModels = new List<UserModel>
            {
                UserModel
            };

            LoggingWork = new Mock<ILoggingWork>();
            ReportingWork = new Mock<IReportingWork>();

            ReportingWork
                .Setup(r => r.GetUser(It.Is<Guid>(u => u == UserModel.Id)))
                .ReturnsAsync(UserModel);

            ReportingWork
                .Setup(r => r.UsersList())
                .ReturnsAsync(UserModels);

            Story = new Story(LoggingWork.Object, ReportingWork.Object);
        }

        [Fact]
        public void Ctor_Null_Args()
        {
            typeof(Story).ConstructorThrowsException(new object[] {
                LoggingWork.Object,
                ReportingWork.Object});
        }

        [Fact]
        public async Task CreateUser_Success()
        {
            //act
            await Story
                .CreateUser(UserModel)
                .ConfigureAwait(false);

            //assert
            LoggingWork.Verify(d => d.CreateUserAsync(It.Is<UserModel>(u => u.Email == UserModel.Email)));
        }

        [Fact]
        public async Task GetUser_Success()
        {
            var user = await Story.GetUser(UserModel.Id).ConfigureAwait(false);

            Assert.Equal(UserModel.Id, user.Id);
        }

        [Fact]
        public async Task UserList_Success()
        {
            var users = await Story.UsersList().ConfigureAwait(false);

            Assert.Single(users);
            Assert.Equal(UserModel.LastName, users[0].LastName);
        }

        [Fact]
        public async Task DeleteUser_Success()
        {
            //act
            await Story
                .DeleteUser(UserModel.Id)
                .ConfigureAwait(false);

            //assert
            LoggingWork.Verify(d => d.DeleteUserAsync(It.Is<Guid>(u => u == UserModel.Id)));
        }

    }
}
