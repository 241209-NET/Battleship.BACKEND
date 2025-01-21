using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class ShipRepository : IShipRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public ShipRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public Ship CreateShip(Ship ship)
    {
        _battleshipContext.Ships.Add(ship);
        _battleshipContext.SaveChanges();
        return ship;
    }

    public IEnumerable<Ship> GetAllShip()
    {
        return _battleshipContext.Ships.ToList();
    }

    public Ship GetShipById(int id)
    {
        var ship = _battleshipContext.Ships.Find(id);
        return ship;
    }

    public Ship UpdateShip(Ship ship)
    {
        _battleshipContext.Ships.Update(ship);
        _battleshipContext.SaveChanges();
        return ship;
    }
}