using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class GameRepository : IGameRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public GameRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;
}