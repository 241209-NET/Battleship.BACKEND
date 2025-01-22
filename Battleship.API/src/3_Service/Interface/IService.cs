using Battleship.API.Model;

namespace Battleship.API.Service;

public interface IBoardService{

    public Board GetBoardById(int id);

    public List<Board> GetBoardsByGameId(int id);

    public Board CreateNewBoard(Board b);
}

public interface ICellFiredService{

    public CellFired GetCellById(int id);
    
    public CellFired NewCellFired(CellFired cell);

    public List<CellFired>? GetAllFiredCells();

    public List<CellFired>? GetAllFiredCellsByBoardId(int boardId);

    public CellFired UpdateCell(CellFired cell);

}

public interface IGameService
{
    public Game CreateGame(Game game);
    public IEnumerable<Game> GetAllGames();
    public Game GetGameById(int id);
    public Game UpdateGame(Game game);
}

public interface IShipService
{
    public Ship CreateShip(Ship ship);
    public IEnumerable<Ship> GetAllShip();
    public Ship GetShipById(int id);
    public Ship UpdateShip(Ship ship);
}

public interface IUserService{}
