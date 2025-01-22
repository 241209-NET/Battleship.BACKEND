
using Battleship.API.Model;

namespace Battleship.API.Repository;

public interface IBoardRepository{}
public interface ICellFiredRepository{}
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
