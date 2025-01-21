using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class BoardRepository : IBoardRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public BoardRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;
}