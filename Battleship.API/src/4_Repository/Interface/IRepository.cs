
using Battleship.API.Model;

namespace Battleship.API.Repository;

public interface IBoardRepository{
    public Board GetBoardById(int id);

    public List<Board> GetBoardsByGameId(int id);

    public Board CreateNewBoard(Board b);

}
public interface ICellFiredRepository{

    public CellFired GetCellById(int id);
    public CellFired NewCellFired(CellFired cell);

    public List<CellFired> GetAllFiredCells();

    public List<CellFired> GetAllFiredCellsByBoardId(int boardId);

    public CellFired UpdateCell(CellFired cell);

    public bool AlreadyFiredAt(int boardId, int x, int y);

}
public interface IGameRepository
{
    public Task<Game> CreateGame(Game game);
    public Task<IEnumerable<Game>> GetAllGames();
    public Task<Game> GetGameById(int id);
    public Task<Game> UpdateGame(Game game);
}
public interface IShipRepository
{
    public Ship CreateShip(Ship ship);
    public IEnumerable<Ship> GetAllShip();
    public Ship GetShipById(int id);
    public Ship UpdateShip(Ship ship);
}
public interface IUserRepository{
    Task<User> CreateUser(User newUser);
    
    Task<User>? GetUserById(int id);
    Task<User>? GetUserByUsername(string username);
    
}
