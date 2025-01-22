using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class GameRepository : IGameRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public GameRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public Game CreateGame(Game game)
    {
        _battleshipContext.Games.Add(game);
        _battleshipContext.SaveChanges();
        return game;
    }

    public IEnumerable<Game> GetAllGames()
    {
        return _battleshipContext.Games.ToList();
    }

    public Game GetGameById(int id)
    {
        var game = _battleshipContext.Games.Find(id);
        return game;
    }

    public Game UpdateGame(Game game)
    {
        _battleshipContext.Games.Update(game);
        _battleshipContext.SaveChanges();
        return game;
    }
}