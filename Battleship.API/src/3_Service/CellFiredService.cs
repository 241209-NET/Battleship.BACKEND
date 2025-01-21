
using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class CellFiredService : ICellFiredService 
{
    private readonly ICellFiredRepository _cellFiredRepository;

    public CellFiredService(ICellFiredRepository cellFiredRepository){
        _cellFiredRepository = cellFiredRepository; 
    }

}