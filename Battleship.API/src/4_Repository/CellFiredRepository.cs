using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class CellFiredRepository : ICellFiredRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public CellFiredRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;


    public CellFired GetCellById(int id){
        return _battleshipContext.CellFired.Find(id);
    }

    public CellFired NewCellFired(CellFired cell){
        _battleshipContext.CellFired.Add(cell);
        _battleshipContext.SaveChanges();
        return cell; 
    }

    public List<CellFired> GetAllFiredCells(){
        return _battleshipContext.CellFired.ToList();
    }

    public List<CellFired> GetAllFiredCellsByBoardId(int boardId){
        return _battleshipContext.CellFired.Where(cell => cell.BoardId == boardId).ToList();
    }

    public CellFired UpdateCell(CellFired cell){
        _battleshipContext.CellFired.Update(cell);
        _battleshipContext.SaveChanges();
        return cell;
    }

}