
using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class ShipService : IShipService 
{
    private readonly IShipRepository _shipRepository;

    public ShipService(IShipRepository shipRepository){
        _shipRepository = shipRepository; 
    }

}