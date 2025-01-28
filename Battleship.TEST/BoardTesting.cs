using Moq; 
using Battleship.API.Model;
using Battleship.API.Service;
using Battleship.API.Repository;
using Battleship.API.Exceptions;
using System.Threading.Tasks;
namespace Battleship.TEST;

public class BoardTesting
{
    [Fact]
    public async Task CreateNewBoard()
    {

    Mock<IBoardRepository> mockBoard = new();
    Mock<IGameRepository> mockGame = new();
    BoardService _boardService = new(mockBoard.Object, mockGame.Object);

    Board board1 = new()
    {
        Id = 1,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board2 = new()
    {
        Id = 2,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    List<Board> boards = [board1];
    

    mockBoard.Setup(m => m.CreateNewBoard(It.IsAny<Board>()))
        .Callback((Board t) => boards.Add(t))  
        .ReturnsAsync(board2);

    await _boardService.CreateNewBoard(board2);

    Assert.Contains(board2, boards);
    mockBoard.Verify(m => m.CreateNewBoard(It.IsAny<Board>()), Times.Once());

    }

    [Fact]
    public async Task GetBoardById()
    {

    Mock<IBoardRepository> mockBoard = new();
    Mock<IGameRepository> mockGame = new();
    BoardService _boardService = new(mockBoard.Object, mockGame.Object);

    Board board1 = new()
    {
        Id = 1,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board2 = new()
    {
        Id = 2,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    List<Board> boards = [board1, board2];
    

    mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
        .ReturnsAsync((int id) => boards.FirstOrDefault(t => t.Id == id));

    var b = await _boardService.GetBoardById(2);

    Assert.Equal(boards[1], b);
    mockBoard.Verify(m => m.GetBoardById(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void GetBoardByIdDNE()
    {

    Mock<IBoardRepository> mockBoard = new();
    Mock<IGameRepository> mockGame = new();
    BoardService _boardService = new(mockBoard.Object, mockGame.Object);

    Board board1 = new()
    {
        Id = 1,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board2 = new()
    {
        Id = 2,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    List<Board> boards = [board1, board2];
    

    mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
        .ReturnsAsync((int id) => boards.FirstOrDefault(t => t.Id == id));

    Assert.ThrowsAsync<DoesNotExistException>(async () => await _boardService.GetBoardById(3));
    mockBoard.Verify(m => m.GetBoardById(It.IsAny<int>()), Times.Once());

    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    public async Task GetBoardsByGameId(int id,int exp)
    {

    Mock<IBoardRepository> mockBoard = new();
    Mock<IGameRepository> mockGame = new();
    BoardService _boardService = new(mockBoard.Object, mockGame.Object);

    Board board1 = new()
    {
        Id = 1,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board2 = new()
    {
        Id = 2,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board3 = new()
    {
        Id = 3,
        GameId = 2,
        UserId = "1",
        IsComputerBoard = false
    };

    Game game1 = new()
    {
        Id = 1,
        UserId = "1",
        Status = true,
        PlayerTurn = true,
        StartTime = DateTime.Now.ToString(),
        EndTime = ""

    };

        Game game2 = new()
    {
        Id = 2,
        UserId = "1",
        Status = true,
        PlayerTurn = true,
        StartTime = DateTime.Now.ToString(),
        EndTime = ""

    };

    List<Board> boards = [board1, board2,board3];
    List<Game> games = [game1,game2];
    

    mockBoard.Setup(m => m.GetBoardsByGameId(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.Where(t => t.GameId == id).ToList());

    mockGame.Setup(m => m.GetGameById(It.IsAny<int>()))
            .ReturnsAsync((int id) => games.FirstOrDefault(t => t.Id == id));

    var result = await _boardService.GetBoardsByGameId(id);

    Assert.Equal(exp, result.Count);
    if (id == 1){
        Assert.Contains(board1, result);
        Assert.Contains(board2, result);
    } 
    if (id == 2){
        Assert.Contains(board3, result);
    }
    
    mockBoard.Verify(m => m.GetBoardsByGameId(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void GetBoardsByGameIdDNE()
    {

    Mock<IBoardRepository> mockBoard = new();
    Mock<IGameRepository> mockGame = new();
    BoardService _boardService = new(mockBoard.Object, mockGame.Object);

    Board board1 = new()
    {
        Id = 1,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board2 = new()
    {
        Id = 2,
        GameId = 1,
        UserId = "1",
        IsComputerBoard = false
    };

    Board board3 = new()
    {
        Id = 3,
        GameId = 2,
        UserId = "1",
        IsComputerBoard = false
    };

    Game game = new()
    {
        Id = 1,
        UserId = "1",
        Status = true,
        PlayerTurn = true,
        StartTime = DateTime.Now.ToString(),
        EndTime = ""

    };

    List<Board> boards = [board1, board2,board3];
    List<Game> games = [game];
    

    mockBoard.Setup(m => m.GetBoardsByGameId(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.Where(t => t.GameId == id).ToList());

    mockGame.Setup(m => m.GetGameById(It.IsAny<int>()))
            .ReturnsAsync((int id) => games.FirstOrDefault(t => t.Id == id));

    Assert.ThrowsAsync<DoesNotExistException>(async () => await _boardService.GetBoardsByGameId(3));
    mockBoard.Verify(m => m.GetBoardsByGameId(It.IsAny<int>()), Times.Never());

    }
}