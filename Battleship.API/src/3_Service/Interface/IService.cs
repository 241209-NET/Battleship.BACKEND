using Battleship.API.DTO;
using Battleship.API.Model;

namespace Battleship.API.Service;

public interface IBoardService{

    public Task<Board> GetBoardById(int id);

    public Task<List<Board>> GetBoardsByGameId(int id);

    public Task<Board> CreateNewBoard(Board b);
}

public interface ICellFiredService{

    public Task<CellFired> GetCellById(int id);
    
    public Task<CellFired> NewCellFired(CellFired cell);

    public Task<List<CellFired>>? GetAllFiredCells();

    public Task<List<CellFired>>? GetAllFiredCellsByBoardId(int boardId);

    public Task<CellFired> UpdateCell(CellFired cell);

    public Task<bool> AlreadyFiredAt(int boardId, int x, int y);
}

public interface IGameService
{
    public Task<Game> CreateGame(Game game);
    public Task<IEnumerable<Game>> GetAllGames(string userID);
    public Task<Game> GetGameById(int id);
    public Task<Game> UpdateGame(Game game);
}

public interface IShipService
{
    public Task<Ship> CreateShip(Ship ship);
    public Task<IEnumerable<Ship>> GetAllShip();
    public Task<Ship> GetShipById(int id);
    public Task<Ship> UpdateShip(Ship ship);
}

public interface IUserService{
    Task<User> CreateUser(User newUser);    
    Task<User>? GetUserById(string id);
    Task<User>? GetUserByUsername(string username);
    Task<IEnumerable<User>> GetAllUsers();
    public Task<UserScoreDTO> UpdateUserScore(string userId, int wins, int losses);
    
}
