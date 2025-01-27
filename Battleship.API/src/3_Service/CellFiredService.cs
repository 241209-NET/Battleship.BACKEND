
using Battleship.API.Repository;
using Battleship.API.Model;
using Battleship.API.Exceptions;
using System.Threading.Tasks;

namespace Battleship.API.Service;

public class CellFiredService : ICellFiredService 
{
    private readonly ICellFiredRepository _cellFiredRepository;
    private readonly IBoardRepository _boardRepository;

    public CellFiredService(ICellFiredRepository cellFiredRepository, IBoardRepository boardRepository){
        _cellFiredRepository = cellFiredRepository; 
        _boardRepository = boardRepository;
    }

    public async Task<CellFired> GetCellById(int id){
        return await _cellFiredRepository.GetCellById(id) ?? throw new DoesNotExistException("Cell not yet fired at!");
    }

    
    public async Task<CellFired> NewCellFired(CellFired cell){

        if (await _boardRepository.GetBoardById(cell.BoardId) == null) throw new DoesNotExistException("No Board Found Matching given ID!");

        if (await AlreadyFiredAt(cell.BoardId, cell.X, cell.Y)) throw new AlreadyExistsException("Space Already Fired At!");
        
        return await _cellFiredRepository.NewCellFired(cell);
    }

    public async Task<List<CellFired>?> GetAllFiredCells(){
        return await _cellFiredRepository.GetAllFiredCells();
    }

    public async Task<List<CellFired>?> GetAllFiredCellsByBoardId(int boardId){
        if (await _boardRepository.GetBoardById(boardId) == null) throw new DoesNotExistException("No Board Found Matching given ID!");
        return await _cellFiredRepository.GetAllFiredCellsByBoardId(boardId);
    }

    public async Task<CellFired> UpdateCell(CellFired cell){
        await GetCellById(cell.Id); // will throw exception if cell doesnt exist
        return await _cellFiredRepository.UpdateCell(cell);
    }
    public async Task<bool> AlreadyFiredAt(int boardId, int x, int y){
        return await _cellFiredRepository.AlreadyFiredAt(boardId, x, y);
    }


}