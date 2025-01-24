
using Battleship.API.Model;

namespace Battleship.API.Repository;

<<<<<<< Updated upstream
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

}
public interface IGameRepository
{
    public Game CreateGame(Game game);
    public IEnumerable<Game> GetAllGames();
    public Game GetGameById(int id);
    public Game UpdateGame(Game game);
}
public interface IShipRepository
{
    public Ship CreateShip(Ship ship);
    public IEnumerable<Ship> GetAllShip();
    public Ship GetShipById(int id);
    public Ship UpdateShip(Ship ship);
}
public interface IUserRepository{}
=======
public interface IBoardRepository{}
public interface ICellFiredRepository{}
public interface IGameRepository{}
public interface IShipRepository{}
public interface IUserRepository{
    Task<User> CreateUser(User newUser);
    
    Task<User>? GetUserById(int id);
    Task<User>? GetUserByUsername(string username);
    
}
>>>>>>> Stashed changes
