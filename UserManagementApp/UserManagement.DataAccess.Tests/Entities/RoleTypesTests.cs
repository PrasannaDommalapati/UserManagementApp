using UserManagement.DataAccess.Entity;
using Xunit;

namespace UserManagement.DataAccess.Tests.Entities
{
    public class RoleTypesTests
    {
        [Fact]
        public void Ctor_Success()
        {
            var result = new RoleTypes
            {
                Id = 10,
                Name = "name"
            };

            Assert.Equal(10, result.Id);
            Assert.Equal("name", result.Name);
        }
    }
}
