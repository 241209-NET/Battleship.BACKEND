
using Battleship.API.Repository;
using Battleship.API.Model;
using System.Threading.Tasks;

namespace Battleship.API.Service;

public class ShipService : IShipService 
{
    private readonly IShipRepository _shipRepository;

    public ShipService(IShipRepository shipRepository){
        _shipRepository = shipRepository; 
    }

    public async Task<Ship> CreateShip(Ship ship)
    {
        var savedShip = await _shipRepository.CreateShip(ship);
        return savedShip;
    }

    public async Task<IEnumerable<Ship>> GetAllShip()
    {
        return await _shipRepository.GetAllShip();
    }

    public async Task<Ship> GetShipById(int id)
    {
        var foundShip = await _shipRepository.GetShipById(id);
        if(foundShip is null)
            throw new Exception("This ship ID does not exist!");
        return foundShip;
    }

    public async Task<Ship> UpdateShip(Ship ship)
    {
        var updatedShip = await GetShipById(ship.Id);
        updatedShip.IsHorizontal = ship.IsHorizontal;
        updatedShip.StartX = ship.StartX;
        updatedShip.StartY = ship.StartY;
        updatedShip.Length = ship.Length;
        await _shipRepository.UpdateShip(updatedShip);
        return updatedShip;
    }
}