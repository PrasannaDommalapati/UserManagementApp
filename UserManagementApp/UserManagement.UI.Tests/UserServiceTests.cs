using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagment.UI.Services;
using Xunit;

namespace UserManagement.UI.Tests
{
    public class UserServiceTests
    {
        private Mock<HttpClient> HttpClient;
        private IUserService UserService;

        public UserServiceTests()
        {
            var userList = new List<UserModel>
            {
                new UserModel
                {
                    Id = 10
                }
            };

            var responsemessage = new HttpResponseMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(userList))
            };

            HttpClient = new Mock<HttpClient>();

            HttpClient
                .Setup(m => m.GetAsync(It.Is<string>(s => s.Equals(@"/api/user"))))
                .Returns(Task.FromResult(responsemessage));

            UserService = new UserService(HttpClient.Object);
        }

        [Fact]
        public void Ctor_Null_HttpClient()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Fact]
        public async Task GetUsers_Returns_SingleUser()
        {
            var result = await UserService.GetUsers().ConfigureAwait(false);


            Assert.Single(result);
        }
    }
}
