using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class ShipRepository : IShipRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public ShipRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;
}