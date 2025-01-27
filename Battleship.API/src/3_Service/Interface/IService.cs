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

}

public interface IGameService
{
    public Task<Game> CreateGame(Game game);
    public Task<IEnumerable<Game>> GetAllGames();
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
    Task<User>? GetUserById(int id);
    Task<User>? GetUserByUsername(string username);
    
}
