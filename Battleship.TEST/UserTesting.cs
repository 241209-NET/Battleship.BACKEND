using Moq; 
using Battleship.API.Model;
using Battleship.API.Service;
using Battleship.API.Repository;
using Battleship.API.Exceptions;
namespace Battleship.TEST;

public class UserTesting
{
    [Fact]
    public async Task CreateNewUser()
    {
        // Arrange
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var newUser = new User
        {
            AccountName = "Jack Sparrow",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(newUser);

        // Act

        var result = await _userService.CreateUser(newUser);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(newUser.AccountName, result.AccountName);
        mockUser.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);

    }

    /*[Fact]
    public async Task GetUserById()
    {

        // Arrange
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var User = new User
        {
            AccountName = "Jack Sparrow",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.GetUserById(1)).ReturnsAsync(User);

        // Act
        var result = await _userService.GetUserById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(User.Id, result.Id);
        mockUser.Verify(repo => repo.GetUserById(1), Times.Once);

    }

    [Fact]
    public async Task GetUserByIdDNE()
    {
        // Arrange
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var User = new User
        {
            Id = 1,
            Username = "player1",
            Password = "1234",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.GetUserById(1)).ReturnsAsync(User);

        var result = await Assert.ThrowsAsync<ArgumentException>(() => _userService.GetUserById(2));

        // Assert
        
        Assert.Equal("User with ID 2 not found.", result.Message);

    }*/

    [Fact]
    public async Task GetUserByUsername()
    {
        // Arrange
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var User = new User
        {
            AccountName = "player1",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.GetUserByUsername("player1")).ReturnsAsync(User);

        // Act
        var result = await _userService.GetUserByUsername("player1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(User.AccountName, result.AccountName);
        mockUser.Verify(repo => repo.GetUserByUsername("player1"), Times.Once);

    }

    [Fact]
    public async Task GetUserByUsernameNullOrWhiteSpace()
    {
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var User = new User
        {
            AccountName = "player1",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.GetUserByUsername("player1")).ReturnsAsync(User);

        var result = await Assert.ThrowsAsync<ArgumentException>(() => _userService.GetUserByUsername(null));

        // Assert
        
        Assert.Equal("Username cannot be null or empty. (Parameter 'username')", result.Message);      
    }

    [Fact]
    public async Task GetUserByUsernameDNE()
    {
        Mock<IUserRepository> mockUser = new();
        UserService _userService = new(mockUser.Object);

        var User = new User
        {
            AccountName = "player1",
            NumWins =  0,
            NumLosses = 0,

        };

        mockUser.Setup(repo => repo.GetUserByUsername("player1")).ReturnsAsync(User);

        var result = await Assert.ThrowsAsync<InvalidOperationException>(() => _userService.GetUserByUsername("someGuy"));

        // Assert
        
        Assert.Equal("User with username 'someGuy' not found.", result.Message);   

    }

}