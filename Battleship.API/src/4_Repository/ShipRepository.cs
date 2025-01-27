using Battleship.API.Model;
using Battleship.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Repository;

public class ShipRepository : IShipRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public ShipRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public async Task<Ship> CreateShip(Ship ship)
    {
        await _battleshipContext.Ships.AddAsync(ship);
        await _battleshipContext.SaveChangesAsync();
        return ship;
    }

    public async Task<IEnumerable<Ship>> GetAllShip()
    {
        return await _battleshipContext.Ships.ToListAsync();
    }

    public async Task<Ship> GetShipById(int id)
    {
        var ship = await _battleshipContext.Ships.FindAsync(id);
        return ship;
    }

    public async Task<Ship> UpdateShip(Ship ship)
    {
        _battleshipContext.Ships.Update(ship);
        await _battleshipContext.SaveChangesAsync();
        return ship;
    }
}