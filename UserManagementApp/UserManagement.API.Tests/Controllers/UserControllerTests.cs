using Bogus;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.API.Controllers;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.API.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Faker Faker;
        private readonly Mock<IStory> Story;
        private readonly UserController Controller;
        private readonly List<UserModel> UserList;

        public UserControllerTests()
        {
            Faker = new Faker();
            Story = new Mock<IStory>();
            Controller = new UserController(Story.Object);

            UserList = new List<UserModel>
            {
                new UserModel
                {
                    Email = Faker.Internet.Email(),
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName()
                },
                new UserModel
                {
                    Email = Faker.Internet.Email(),
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName()
                }
            };
            //mock setup
            Story.Setup(f => f.UsersList()).Returns(Task.FromResult(UserList));
        }

        [Fact]
        public async Task GetUsers_ReturnsAll_Users()
        {
            // Act
            var result = await Controller.GetUsers().ConfigureAwait(false);

            // Assert
            Assert.Equal(UserList.Count, result.Count);
        }
    }
}
