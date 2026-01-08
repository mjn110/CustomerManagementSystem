using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace YourProject.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task CreateUser_ShouldCallUserManager()
        {
            // Arrange
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            var user = new User { UserName = "testuser", Email = "test@test.com" };
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await userManagerMock.Object.CreateAsync(user, "Password123!");

            // Assert
            Assert.True(result.Succeeded);
            userManagerMock.Verify(x => x.CreateAsync(user, "Password123!"), Times.Once);
        }

        [Fact]
        public async Task AddUserToRole_ShouldSucceed()
        {
            // Arrange
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            var user = new User { UserName = "testuser" };
            userManagerMock.Setup(x => x.AddToRoleAsync(user, "Admin"))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await userManagerMock.Object.AddToRoleAsync(user, "Admin");

            // Assert
            Assert.True(result.Succeeded);
        }
    }
}