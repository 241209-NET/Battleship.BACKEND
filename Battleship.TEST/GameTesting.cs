using Moq; 
using Battleship.API.Model;
using Battleship.API.Service;
using Battleship.API.Repository;
using Battleship.API.Exceptions;
namespace Battleship.TEST;

public class GameTesting
{
    [Fact]
    public async Task CreateNewGame()
    {
        // Arrange
        Mock<IGameRepository> mockGame = new();
        GameService _gameService = new(mockGame.Object);

        var newGame = new Game
        {
            Id = 1,
            UserId = "1",
            Status = true,
            PlayerTurn = true,
            StartTime = "",
            EndTime = "",

        };

        mockGame.Setup(repo => repo.CreateGame(It.IsAny<Game>())).ReturnsAsync(newGame);

        // Act

        var result = await _gameService.CreateGame(newGame);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(newGame.Id, result.Id);
        mockGame.Verify(repo => repo.CreateGame(It.IsAny<Game>()), Times.Once);

    }

    [Fact]
    public async Task GetGameById()
    {

        // Arrange
        Mock<IGameRepository> mockGame = new();
        GameService _gameService = new(mockGame.Object);

        var newGame = new Game
        {
            Id = 1,
            UserId = "1",
            Status = true,
            PlayerTurn = true,
            StartTime = "",
            EndTime = "",

        };

        mockGame.Setup(repo => repo.GetGameById(1)).ReturnsAsync(newGame);

        // Act
        var result = await _gameService.GetGameById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newGame.Id, result.Id);
        mockGame.Verify(repo => repo.GetGameById(1), Times.Once);

    }

    [Fact]
    public async Task GetGameByIdDNE()
    {
        // Arrange
        Mock<IGameRepository> mockGame = new();
        GameService _gameService = new(mockGame.Object);

        var newGame = new Game
        {
            Id = 1,
            UserId = "1",
            Status = true,
            PlayerTurn = true,
            StartTime = "",
            EndTime = "",

        };

        mockGame.Setup(repo => repo.GetGameById(1)).ReturnsAsync(newGame);

        var result = await Assert.ThrowsAsync<Exception>(() => _gameService.GetGameById(2));

        // Assert
        
        Assert.Equal("This game ID does not exist!", result.Message);

    }

    [Fact]
    public async Task GetAllGames()
    {
        // Arrange
        Mock<IGameRepository> mockGame = new();
        GameService _gameService = new(mockGame.Object);
        var games = new List<Game>
        {
            new Game
            {
            Id = 1,
            UserId = "1",
            Status = true,
            PlayerTurn = true,
            StartTime = "",
            EndTime = "",

            },
            new Game
            {
                Id = 2,
                UserId = "2",
                Status = true,
                PlayerTurn = true,
                StartTime = "",
                EndTime = "",
            },
        };

        mockGame.Setup(repo => repo.GetAllGames()).ReturnsAsync(games);

        // Act
        var result = await _gameService.GetAllGames();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(games.Count, result.Count());
        mockGame.Verify(repo => repo.GetAllGames(), Times.Once);
    }

    [Fact]
    public async Task UpdateGame()
    {
        // Arrange
        Mock<IGameRepository> mockGame = new();
        GameService _gameService = new(mockGame.Object);

        var newGame = new Game
        {
            Id = 1,
            UserId = "1",
            Status = true,
            PlayerTurn = true,
            StartTime = "",
            EndTime = "",

        };
        var updatedGame = new Game
        {
                Id = 1,
                UserId = "1",
                Status = false,
                PlayerTurn = false,
                StartTime = "",
                EndTime = "",
        };
        
        mockGame.Setup(repo => repo.GetGameById(1)).ReturnsAsync(newGame);
        mockGame.Setup(repo => repo.UpdateGame(newGame)).ReturnsAsync(updatedGame);

        // Act
        
        var result = await _gameService.UpdateGame(updatedGame);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(updatedGame.Status, result.Status);
    }


}