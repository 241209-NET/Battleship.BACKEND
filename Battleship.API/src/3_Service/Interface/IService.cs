using Battleship.API.Model;

namespace Battleship.API.Service;

public interface IBoardService{}

public interface ICellFiredService{}

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
