using Bogus;
using Moq;
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
        private readonly IStory Story;
        private readonly Faker Faker;

        public StoryTests()
        {
            Faker = new Faker();
            LoggingWork = new Mock<ILoggingWork>();
            ReportingWork = new Mock<IReportingWork>();
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
            //arrange
            var email = Faker.Internet.Email();
            var user = new UserModel
            {
                Email = email,
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
            };

            //act
            await Story
                .CreateUser(user)
                .ConfigureAwait(false);

            //assert
            LoggingWork.Verify(d => d.CreateUserAsync(It.Is<UserModel>(u => u.Email == email)));
        }
    }
}
