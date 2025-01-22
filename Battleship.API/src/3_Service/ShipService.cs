
using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class ShipService : IShipService 
{
    private readonly IShipRepository _shipRepository;

    public ShipService(IShipRepository shipRepository){
        _shipRepository = shipRepository; 
    }

    public Ship CreateShip(Ship ship)
    {
        var savedShip = _shipRepository.CreateShip(ship);
        return savedShip;
    }

    public IEnumerable<Ship> GetAllShip()
    {
        return _shipRepository.GetAllShip();
    }

    public Ship GetShipById(int id)
    {
        var foundShip = _shipRepository.GetShipById(id);
        if(foundShip is null)
            throw new Exception("This ship ID does not exist!");
        return foundShip;
    }

    public Ship UpdateShip(Ship ship)
    {
        var updatedShip = GetShipById(ship.Id);
        updatedShip.IsHorizontal = ship.IsHorizontal;
        updatedShip.StartX = ship.StartX;
        updatedShip.StartY = ship.StartY;
        updatedShip.Length = ship.Length;
        _shipRepository.UpdateShip(updatedShip);
        return updatedShip;
    }
}