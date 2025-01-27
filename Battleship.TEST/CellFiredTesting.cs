using Moq; 
using Battleship.API.Model;
using Battleship.API.Service;
using Battleship.API.Repository;
using Battleship.API.Exceptions;
using System.Threading.Tasks;
namespace Battleship.TEST;

public class CellFiredTesting
{

    [Fact]
    public async Task CreateNewCell(){
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        Board board1 = new()
        {
            Id = 1,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };

        List<CellFired> cells = [cell1];
        List<Board> boards = [board1]; 

        mockCell.Setup(m => m.NewCellFired(It.IsAny<CellFired>()))
            .Callback((CellFired t) => cells.Add(t))  
            .ReturnsAsync(cell2);

        mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.FirstOrDefault(b => b.Id == id));
        
        await _cellService.NewCellFired(cell2);

        Assert.Contains(cell2, cells);
        mockCell.Verify(m => m.NewCellFired(It.IsAny<CellFired>()), Times.Once());

    }

    [Fact]
    public void CreateNewCellBoardDNE(){
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 2,
            Status = "Miss"
        };

        Board board1 = new()
        {
            Id = 1,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };

        List<CellFired> cells = [cell1];
        List<Board> boards = [board1]; 

        mockCell.Setup(m => m.NewCellFired(It.IsAny<CellFired>()))
            .Callback((CellFired t) => cells.Add(t))  
            .ReturnsAsync(cell2);

        mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.FirstOrDefault(b => b.Id == id));
        

        Assert.ThrowsAsync<DoesNotExistException>(async () => await _cellService.NewCellFired(cell2));
        mockCell.Verify(m => m.NewCellFired(It.IsAny<CellFired>()), Times.Never());

    }

    [Fact]
    public void CreateNewCellAlreadyShot(){

        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        Board board1 = new()
        {
            Id = 1,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };

        Board board2 = new()
        {
            Id = 2,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };


        List<CellFired> cells = [cell1];
        List<Board> boards = [board1, board2];

        mockCell.Setup(m => m.NewCellFired(It.IsAny<CellFired>()))
            .Callback((CellFired t) => cells.Add(t))  
            .ReturnsAsync(cell2);

        mockCell.Setup(m => m.AlreadyFiredAt(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
        .Returns((int boardId, int x, int y) => {
            var found = cells.Any(cell => boardId == cell.BoardId && x == cell.X && y == cell.Y);
            return found;
        });

        mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.FirstOrDefault(t => t.Id == id));




        Assert.ThrowsAsync<AlreadyExistsException>(async () => await _cellService.NewCellFired(cell2));
        mockCell.Verify(m => m.NewCellFired(It.IsAny<CellFired>()), Times.Never());

    }


    [Fact]
    public async Task GetCellById(){
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        List<CellFired> cells = [cell1, cell2];

        mockCell.Setup(m => m.GetCellById(It.IsAny<int>())) 
            .ReturnsAsync((int id) => cells.FirstOrDefault(t => t.Id == id));
        
        var c = await _cellService.GetCellById(1);

        Assert.Equal(cells[0], c);
        mockCell.Verify(m => m.GetCellById(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void GetCellByIdDNE(){
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        List<CellFired> cells = [cell1, cell2];

        mockCell.Setup(m => m.GetCellById(It.IsAny<int>())) 
            .ReturnsAsync((int id) => cells.FirstOrDefault(t => t.Id == id));


        Assert.ThrowsAsync<DoesNotExistException>(() => _cellService.GetCellById(3));
        mockCell.Verify(m => m.GetCellById(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public async Task GetAllFiredCells(){
        
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 2,
            Status = "Miss"
        };

        List<CellFired> cells = [cell1, cell2];

        mockCell.Setup(m => m.GetAllFiredCells()) 
            .ReturnsAsync(cells);
        
        var c = await _cellService.GetAllFiredCells();

        Assert.Equal(cells, c);
        mockCell.Verify(m => m.GetAllFiredCells(), Times.Once());

    }

    [Theory]
    [InlineData(1,3)]
    [InlineData(2,1)]

    public async Task GetAllFiredCellsByBoardId(int id, int count){
        
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        CellFired cell3 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 2,
            Status = "Hit"
        };

        CellFired cell4 = new()
        {
            Id = 2,
            X = 1,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        Board board1 = new()
        {
            Id = 1,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };

        Board board2 = new()
        {
            Id = 2,
            GameId = 1,
            UserId = 1,
            IsComputerBoard = false
        };


        List<CellFired> cells = [cell1, cell2,cell3,cell4];
        List<Board> boards = [board1, board2];

        mockCell.Setup(m => m.GetAllFiredCellsByBoardId(It.IsAny<int>()))
            .ReturnsAsync((int id) => cells.Where(t => t.BoardId == id).ToList());

        mockBoard.Setup(m => m.GetBoardById(It.IsAny<int>()))
            .ReturnsAsync((int id) => boards.FirstOrDefault(t => t.Id == id));
        
        var c = await _cellService.GetAllFiredCellsByBoardId(id);
        Assert.Equal(count, c.Count);
        if (id == 1){
            Assert.Contains(cell1, c);
            Assert.Contains(cell2, c);
            Assert.Contains(cell4, c);
        }
        if (id ==2){
            Assert.Contains(cell3, c);
        }

        mockCell.Verify(m => m.GetAllFiredCellsByBoardId(It.IsAny<int>()), Times.Once());

    }


// UPDATE

    [Fact]
    public async Task UpdateCell(){
        
        Mock<ICellFiredRepository> mockCell = new();
        Mock<IBoardRepository> mockBoard = new();
        CellFiredService _cellService = new(mockCell.Object, mockBoard.Object);

        CellFired cell1 = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Hit"
        };

        CellFired cell2update = new()
        {
            Id = 1,
            X = 0,
            Y = 0,
            BoardId = 1,
            Status = "Miss"
        };

        List<CellFired> cells = [cell1];

        mockCell.Setup(m => m.UpdateCell(It.IsAny<CellFired>()))
            .ReturnsAsync((CellFired cell) =>{
                var found = cells.Find(c => c.Id == cell.Id);
                found.Status = cell.Status;
                found.X = cell.X;
                found.Y = cell.Y;
                return found; 
            });

        mockCell.Setup(m => m.GetCellById(It.IsAny<int>())) 
            .ReturnsAsync((int id) => cells.FirstOrDefault(t => t.Id == id));

        var c = await _cellService.UpdateCell(cell2update);
        var check = await _cellService.GetCellById(1);

        Assert.Equal("Miss", check.Status);
        mockCell.Verify(m => m.UpdateCell(It.IsAny<CellFired>()), Times.Once());

    }

}