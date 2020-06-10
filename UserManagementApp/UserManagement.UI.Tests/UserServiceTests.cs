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
        private HttpClient HttpClient;
        private IUserService UserService;

        public UserServiceTests()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44372")
            };

            UserService = new UserService(HttpClient);
        }

        [Fact]
        public void Ctor_Null_HttpClient()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Fact]
        public async Task GetUsers_Returns_SingleUser()
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

            //HttpClient
            //   .Setup(m => m.GetAsync(It.Is<string>(s => s.Equals(@"/api/user"))))
            //   .Returns(Task.FromResult(responsemessage));

            var result = await UserService.GetUsers().ConfigureAwait(false);


            Assert.Single(result);
        }
    }
}
