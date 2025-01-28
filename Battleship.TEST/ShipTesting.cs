using Moq; 
using Battleship.API.Model;
using Battleship.API.Service;
using Battleship.API.Repository;
using Battleship.API.Exceptions;
namespace Battleship.TEST;

public class ShipTesting
{
    [Fact]
    public async Task CreateNewShip()
    {
        // Arrange
        Mock<IShipRepository> mockShip = new();
        ShipService _shipService = new(mockShip.Object);

        var newShip = new Ship
        {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 1,
            StartY = 1,

        };

        mockShip.Setup(repo => repo.CreateShip(It.IsAny<Ship>())).ReturnsAsync(newShip);

        // Act

        var result = await _shipService.CreateShip(newShip);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(newShip.Id, result.Id);
        mockShip.Verify(repo => repo.CreateShip(It.IsAny<Ship>()), Times.Once);

    }

    [Fact]
    public async Task GetAllShip()
    {
        // Arrange
        Mock<IShipRepository> mockShip = new();
        ShipService _shipService = new(mockShip.Object);
        var ships = new List<Ship>
        {
            new Ship
            {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 1,
            StartY = 1,

            },
            new Ship
            {
            Id = 1,
            BoardId = 2,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = false,
            StartX = 1,
            StartY = 1,
            },
        };

        mockShip.Setup(repo => repo.GetAllShip()).ReturnsAsync(ships);

        // Act
        var result = await _shipService.GetAllShip();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ships.Count, result.Count());
        mockShip.Verify(repo => repo.GetAllShip(), Times.Once);
    }

    [Fact]
    public async Task GetShipById()
    {

        // Arrange
        Mock<IShipRepository> mockShip = new();
        ShipService _shipService = new(mockShip.Object);

        var Ship = new Ship
        {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 1,
            StartY = 1,
        };

        mockShip.Setup(repo => repo.GetShipById(1)).ReturnsAsync(Ship);

        // Act
        var result = await _shipService.GetShipById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Ship.Id, result.Id);
        mockShip.Verify(repo => repo.GetShipById(1), Times.Once);

    }

    [Fact]
    public async Task GetShipByIdDNE()
    {
        // Arrange
        Mock<IShipRepository> mockShip = new();
        ShipService _shipService = new(mockShip.Object);

        var Ship = new Ship
        {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 1,
            StartY = 1,

        };

        mockShip.Setup(repo => repo.GetShipById(1)).ReturnsAsync(Ship);

        var result = await Assert.ThrowsAsync<Exception>(() => _shipService.GetShipById(2));

        // Assert
        
        Assert.Equal("This ship ID does not exist!", result.Message);
    }

    [Fact]
    public async Task UpdateShip()
    {
        // Arrange
        Mock<IShipRepository> mockShip = new();
        ShipService _shipService = new(mockShip.Object);

        var newShip = new Ship
        {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 1,
            StartY = 1,

        };
        var updatedShip = new Ship
        {
            Id = 1,
            BoardId = 1,
            Type = "Destroyer",
            Length = 5,
            IsHorizontal = true,
            StartX = 2,
            StartY = 2,
        };
        
        mockShip.Setup(repo => repo.GetShipById(1)).ReturnsAsync(newShip);
        mockShip.Setup(repo => repo.UpdateShip(newShip)).ReturnsAsync(updatedShip);

        // Act
        
        var result = await _shipService.UpdateShip(updatedShip);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(updatedShip.StartX, result.StartX);
    }
}