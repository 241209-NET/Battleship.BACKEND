
using Battleship.API.Repository;
using Battleship.API.Model;
using Battleship.API.Exceptions;

namespace Battleship.API.Service;

public class CellFiredService : ICellFiredService 
{
    private readonly ICellFiredRepository _cellFiredRepository;
    private readonly IBoardRepository _boardRepository;

    public CellFiredService(ICellFiredRepository cellFiredRepository, IBoardRepository boardRepository){
        _cellFiredRepository = cellFiredRepository; 
        _boardRepository = boardRepository;
    }

    public CellFired GetCellById(int id){
        return _cellFiredRepository.GetCellById(id) ?? throw new DoesNotExistException("Cell not yet fired at!");
    }

    
    public CellFired NewCellFired(CellFired cell){
        if (_cellFiredRepository.GetCellById(cell.Id) != null) throw new AlreadyExistsException("Space Already Fired At!");
        return _cellFiredRepository.NewCellFired(cell);
    }

    public List<CellFired>? GetAllFiredCells(){
        return _cellFiredRepository.GetAllFiredCells();
    }

    public List<CellFired>? GetAllFiredCellsByBoardId(int boardId){
        if (_boardRepository.GetBoardById(boardId) == null) throw new DoesNotExistException("No Board Found Matching given ID!");
        return _cellFiredRepository.GetAllFiredCellsByBoardId(boardId);
    }

    public CellFired UpdateCell(CellFired cell){
        GetCellById(cell.Id); // will throw exception if cell doesnt exist
        return _cellFiredRepository.UpdateCell(cell);
    }


}