using Bogus;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Business.Tests.Models
{
    public class UserRoleModelTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();
            var id = faker.Random.Number();
            var role = faker.Random.String();

            var result = new UserRoleModel
            {
                Id = id,
                Role = role
            };

            Assert.Equal(id, result.Id);
            Assert.Equal(role, result.Role);
        }
    }
}
