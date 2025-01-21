using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class CellFiredRepository : ICellFiredRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public CellFiredRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;
}