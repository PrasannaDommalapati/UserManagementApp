using System;
using UserManagment.UI.Services;
using Xunit;

namespace UserManagement.UI.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void Ctor_Null_HttpClient()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

    }
}
