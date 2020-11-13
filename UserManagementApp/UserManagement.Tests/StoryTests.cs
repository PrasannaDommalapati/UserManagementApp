using Bogus;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Business;
using UserManagement.Business.Helpers;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Tests
{
    public class StoryTests
    {
        private readonly Mock<ILoggingWork> _loggingWork;
        private readonly Mock<IReportingWork> _reportingWork;
        private readonly IUserStory Story;
        private readonly UserModel _userModel;

        public StoryTests()
        {
            var faker = new Faker();

            _userModel = new UserModel
            {
                Id = faker.Random.Number(),
                Email = faker.Internet.Email(),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
            };
            var userModelList = new List<UserModel>
            {
                _userModel
            };

            _loggingWork = new Mock<ILoggingWork>();
            _reportingWork = new Mock<IReportingWork>();

            _reportingWork
                .Setup(r => r.GetUser(It.Is<int>(u => u == _userModel.Id)))
                .ReturnsAsync(_userModel);

            _reportingWork
                .Setup(r => r.UsersList())
                .ReturnsAsync(userModelList);

            Story = new UserStory(_loggingWork.Object, _reportingWork.Object);
        }

        [Fact]
        public void Ctor_Null_Args()
        {
            typeof(UserStory).ConstructorThrowsException(new object[] {
                _loggingWork.Object,
                _reportingWork.Object});
        }

        [Fact]
        public async Task CreateUser_Success()
        {
            //act
            await Story
                .CreateUser(_userModel)
                .ConfigureAwait(false);

            //assert
            _loggingWork.Verify(d => d.CreateUserAsync(It.Is<UserModel>(u => u.Email == _userModel.Email)));
        }

        [Fact]
        public async Task GetUser_Success()
        {
            var user = await Story.GetUser(_userModel.Id).ConfigureAwait(false);

            Assert.Equal(_userModel.Id, user.Id);
        }

        [Fact]
        public async Task UserList_Success()
        {
            var users = await Story.UsersList().ConfigureAwait(false);

            Assert.Single(users);
            Assert.Equal(_userModel.LastName, users.First().LastName);
        }

        [Fact]
        public async Task DeleteUser_Success()
        {
            //act
            await Story
                .DeleteUser(_userModel.Id)
                .ConfigureAwait(false);

            //assert
            _loggingWork.Verify(d => d.DeleteUserAsync(It.Is<int>(u => u == _userModel.Id)));
        }

    }
}
