using Battleship.API.Model;
using Battleship.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Repository;

public class CellFiredRepository : ICellFiredRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public CellFiredRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;


    public async Task<CellFired> GetCellById(int id){
        return await _battleshipContext.CellFired.FindAsync(id);
    }

    public async Task<CellFired> NewCellFired(CellFired cell){
        await _battleshipContext.CellFired.AddAsync(cell);
        await _battleshipContext.SaveChangesAsync();
        return cell; 
    }

    public async Task<List<CellFired>> GetAllFiredCells(){
        return await _battleshipContext.CellFired.ToListAsync();
    }

    public async Task<List<CellFired>> GetAllFiredCellsByBoardId(int boardId){
        return await _battleshipContext.CellFired.Where(cell => cell.BoardId == boardId).ToListAsync();
    }

    public async Task<CellFired> UpdateCell(CellFired cell){
        _battleshipContext.CellFired.Update(cell);
        await _battleshipContext.SaveChangesAsync();
        return cell;
    }

    public bool AlreadyFiredAt(int boardId, int x, int y)
    {
        return _battleshipContext.CellFired.Where(b => b.BoardId == boardId).Any(cell => cell.X == x && cell.Y == y);
    }

}