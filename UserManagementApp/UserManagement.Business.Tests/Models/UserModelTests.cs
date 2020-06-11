using Bogus;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Business.Tests.Models
{
    public class UserModelTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();

            var id = faker.Random.Guid();
            var email = faker.Random.String();
            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var birthday = faker.Date.Recent(500);
            var modified = faker.Date.Recent(1);

            var result = new UserModel
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday,
                DateModified = modified
            };

            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstName, result.FirstName);
            Assert.Equal(lastName, result.LastName);
            Assert.Equal(birthday, result.Birthday);
            Assert.Equal(modified, result.DateModified);

        }
    }
}
