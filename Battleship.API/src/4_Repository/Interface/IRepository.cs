
using Battleship.API.Model;

namespace Battleship.API.Repository;

public interface IBoardRepository{
    public Task<Board> GetBoardById(int id);

    public Task<List<Board>> GetBoardsByGameId(int id);

    public Task<Board> CreateNewBoard(Board b);

}
public interface ICellFiredRepository{

    public Task<CellFired> GetCellById(int id);
    public Task<CellFired> NewCellFired(CellFired cell);

    public Task<List<CellFired>> GetAllFiredCells();

    public Task<List<CellFired>> GetAllFiredCellsByBoardId(int boardId);

    public Task<CellFired> UpdateCell(CellFired cell);

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
